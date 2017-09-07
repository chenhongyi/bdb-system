﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2.Common
{
    public class Config
    {
        public int QrCodeId { get; set; }
        /// <summary>
        /// chm版
        /// </summary>
        public List<string> Versions { get; set; }
        /// <summary>
        /// 网页版
        /// </summary>
        public List<string> WebVersions { get; set; }
        public int DownloadCount { get; set; }
    }
}
