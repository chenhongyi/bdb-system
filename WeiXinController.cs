using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP;
using Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Senparc.Weixin;
using CommonService;

namespace Web.Controllers
{
    public class WeiXinController : Controller
    {
        [HttpPost]
        public IActionResult Index(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, DefineModel.Token))
            {
                return Content("��������");
            }
            #region ��� PostModel ��Ϣ
            postModel.Token = DefineModel.Token;
            postModel.EncodingAESKey = DefineModel.EncodingAESKey;
            postModel.AppId = DefineModel.AppId;
            #endregion

            //v4.2.2֮��İ汾����������ÿ������������Ϣ����������������ֹ�ڴ�ռ�ù��࣬����ò���С�ڵ���0��������
            var maxRecordCount = 10;

            string body = new StreamReader(Request.Body).ReadToEnd();
            byte[] requestData = Encoding.UTF8.GetBytes(body);
            Stream inputStream = new MemoryStream(requestData);

            var messageHandler = new CustomMessageHandler(inputStream, postModel, maxRecordCount);


            try
            {

                #region ��¼ Request ��־

                var logPath = Server.GetMapPath(string.Format("~/App_Data/MP/{0}/", DateTime.Now.ToString("yyyy-MM-dd")));
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                //����ʱ�ɿ����˼�¼�������������ݣ�ʹ��ǰ��ȷ��App_Data�ļ��д��ڣ����ж�дȨ�ޡ�

                var requestDocumentFileName = Path.Combine(logPath, string.Format("{0}_Request_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName));
                var ecryptRequestDocumentFileName = Path.Combine(logPath, string.Format("{0}_Request_Ecrypt_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName));

                using (FileStream fs = new FileStream(requestDocumentFileName, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    messageHandler.RequestDocument.Save(fs);
                }
                if (messageHandler.UsingEcryptMessage)
                {
                    using (FileStream fs = new FileStream(ecryptRequestDocumentFileName, FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        messageHandler.EcryptRequestDocument.Save(fs);
                    }
                }

                #endregion

                /* �����Ҫ�����Ϣȥ�ع��ܣ�ֻ���OmitRepeatedMessage���ܣ�SDK���Զ�����
                 * �յ��ظ���Ϣͨ������Ϊ΢�ŷ�����û�м�ʱ�յ���Ӧ�����������2-5�����ȵ���ͬ���ݵ�RequestMessage*/
                messageHandler.OmitRepeatedMessage = true;

                //ִ��΢�Ŵ������
                messageHandler.Execute();

                #region ��¼ Response ��־

                //����ʱ�ɿ�����������������

                //if (messageHandler.ResponseDocument == null)
                //{
                //    throw new Exception(messageHandler.RequestDocument.ToString());
                //}

                var responseDocumentFileName = Path.Combine(logPath, string.Format("{0}_Response_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName));
                var ecryptResponseDocumentFileName = Path.Combine(logPath, string.Format("{0}_Response_Final_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName));

                if (messageHandler.ResponseDocument != null)
                {
                    using (FileStream fs = new FileStream(responseDocumentFileName, FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        messageHandler.ResponseDocument.Save(fs);
                    }
                }

                if (messageHandler.UsingEcryptMessage && messageHandler.FinalResponseDocument != null)
                {
                    using (FileStream fs = new FileStream(ecryptResponseDocumentFileName, FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        //��¼���ܺ����Ӧ��Ϣ
                        messageHandler.FinalResponseDocument.Save(fs);
                    }
                }

                #endregion`

                //return Content(messageHandler.ResponseDocument.ToString());//v0.7-
                //return new WeixinResult(messageHandler);//v0.8+
                return new FixWeixinBugWeixinResult(messageHandler);//Ϊ�˽���ٷ�΢��5.0�������bug��ʱ��ӵķ�����ƽʱ������һ����������
            }
            catch (Exception ex)
            {
                #region �쳣����
                WeixinTrace.Log("MessageHandler����{0}", ex.Message);


                using (var fs = new FileStream(Server.GetMapPath("~/App_Data/Error_" + _getRandomFileName() + ".txt"), FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        tw.WriteLine("ExecptionMessage:" + ex.Message);
                        tw.WriteLine(ex.Source);
                        tw.WriteLine(ex.StackTrace);
                        //tw.WriteLine("InnerExecptionMessage:" + ex.InnerException.Message);

                        if (messageHandler.ResponseDocument != null)
                        {
                            tw.WriteLine(messageHandler.ResponseDocument.ToString());
                        }

                        if (ex.InnerException != null)
                        {
                            tw.WriteLine("========= InnerException =========");
                            tw.WriteLine(ex.InnerException.Message);
                            tw.WriteLine(ex.InnerException.Source);
                            tw.WriteLine(ex.InnerException.StackTrace);
                        }

                        tw.Flush();
                        //tw.Close();
                    }
                }
                return Content("");
                #endregion
            }
        }
    }
}