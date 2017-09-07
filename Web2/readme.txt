dotnet ef migrations add [Name]

dotnet ef database update



<h2>Test2_Checkboxlist</h2>  
@using MedCrab.Core.Model.APP  
@{  
    List<htTagEx> tags = ViewBag.Tags;     
}  
<div class="margin:10px auto;">  
 @{  
   
  foreach(var t in tags)   //设置伪Checkboxlist  
   {  
     string _checked = "";  //设置_checked变量进行checkbox的默认设置选项  
     <label>  
            @if(t.fState==0) //fState为数据库字段，设置保存此标签是否被选择  
            {  
                <input type="checkbox" name="tags" value="@t.fName" @_checked/>@t.fName    
            }  
            else  
            {  
                _checked = "checked=";  
                <input type="checkbox" name="tags" value="@t.fName" @_checked />@t.fName  
            }  
     </label>  
   }  
 }  
     
</div>  


/// <summary>  
 /// 显示标签  
 /// </summary>  
 /// <returns></returns>  
[HttpGet]  
  public ActionResult Test2()   
  {  
    //从数据库中拿出所有标签进行显示  
    TagService tagService=new TagService();  
    ViewBag.Tags = tagService.GetTagList(); //得到标签列表  
     return View();  
  }  
 /// <summary>  
 /// 对已经选择的标签进行识别保存  
 /// </summary>  
 /// <returns></returns>  
[HttpPost]  
public ActionResult Test2(htTag tags)  
{  
    TagService tagService = new TagService();  
    ViewBag.Tags = tagService.GetTagList();  
    if (ModelState.IsValid) //是否被用户选中  
    {  
      //填充保存选择标签  
    }  
    return View();  
}  