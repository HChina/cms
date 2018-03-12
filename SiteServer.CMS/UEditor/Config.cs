﻿using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using SiteServer.CMS.Core;
using SiteServer.CMS.Plugin;

namespace SiteServer.CMS.UEditor
{
    /// <summary>
    /// Config 的摘要说明
    /// </summary>
    public static class Config
    {
        private static bool noCache = true;
        private static JObject BuildItems()
        {
            if (string.IsNullOrEmpty(Request.CurrentAdministratorName)) return new JObject();

                var json = @"/* 前后端通信相关的配置,注释只允许使用多行方式 */
{
    /* 上传图片配置项 */
    ""imageActionName"": ""uploadimage"", /* 执行上传图片的action名称 */
    ""imageFieldName"": ""upfile"", /* 提交的图片表单名称 */
    ""imageMaxSize"": 2048000, /* 上传大小限制，单位B */
    ""imageAllowFiles"": ["".png"", "".jpg"", "".jpeg"", "".gif"", "".bmp""], /* 上传图片格式显示 */
    ""imageCompressEnable"": true, /* 是否压缩图片,默认是true */
    ""imageCompressBorder"": 1600, /* 图片压缩最长边限制 */
    ""imageInsertAlign"": ""none"", /* 插入的图片浮动方式 */
    ""imageUrlPrefix"": """", /* 图片访问路径前缀 */
    ""imagePathFormat"": ""upload/image/{yyyy}{mm}{dd}/{time}{rand:6}"", /* 上传保存路径,可以自定义保存路径和文件名格式 */
                                /* {filename} 会替换成原文件名,配置这项需要注意中文乱码问题 */
                                /* {rand:6} 会替换成随机数,后面的数字是随机数的位数 */
                                /* {time} 会替换成时间戳 */
                                /* {yyyy} 会替换成四位年份 */
                                /* {yy} 会替换成两位年份 */
                                /* {mm} 会替换成两位月份 */
                                /* {dd} 会替换成两位日期 */
                                /* {hh} 会替换成两位小时 */
                                /* {ii} 会替换成两位分钟 */
                                /* {ss} 会替换成两位秒 */
                                /* 非法字符 \ : * ? "" < > | */
                                /* 具请体看线上文档: fex.baidu.com/ueditor/#use-format_upload_filename */

    /* 涂鸦图片上传配置项 */
    ""scrawlActionName"": ""uploadscrawl"", /* 执行上传涂鸦的action名称 */
    ""scrawlFieldName"": ""upfile"", /* 提交的图片表单名称 */
    ""scrawlPathFormat"": ""upload/image/{yyyy}{mm}{dd}/{time}{rand:6}"", /* 上传保存路径,可以自定义保存路径和文件名格式 */
    ""scrawlMaxSize"": 2048000, /* 上传大小限制，单位B */
    ""scrawlUrlPrefix"": """", /* 图片访问路径前缀 */
    ""scrawlInsertAlign"": ""none"",

    /* 截图工具上传 */
    ""snapscreenActionName"": ""uploadimage"", /* 执行上传截图的action名称 */
    ""snapscreenPathFormat"": ""upload/image/{yyyy}{mm}{dd}/{time}{rand:6}"", /* 上传保存路径,可以自定义保存路径和文件名格式 */
    ""snapscreenUrlPrefix"": """", /* 图片访问路径前缀 */
    ""snapscreenInsertAlign"": ""none"", /* 插入的图片浮动方式 */

    /* 抓取远程图片配置 */
    ""catcherLocalDomain"": [""127.0.0.1"", ""localhost"", ""img.baidu.com""],
    ""catcherActionName"": ""catchimage"", /* 执行抓取远程图片的action名称 */
    ""catcherFieldName"": ""source"", /* 提交的图片列表表单名称 */
    ""catcherPathFormat"": ""upload/image/{yyyy}{mm}{dd}/{time}{rand:6}"", /* 上传保存路径,可以自定义保存路径和文件名格式 */
    ""catcherUrlPrefix"": """", /* 图片访问路径前缀 */
    ""catcherMaxSize"": 2048000, /* 上传大小限制，单位B */
    ""catcherAllowFiles"": ["".png"", "".jpg"", "".jpeg"", "".gif"", "".bmp""], /* 抓取图片格式显示 */

    /* 上传视频配置 */
    ""videoActionName"": ""uploadvideo"", /* 执行上传视频的action名称 */
    ""videoFieldName"": ""upfile"", /* 提交的视频表单名称 */
    ""videoPathFormat"": ""upload/video/{yyyy}{mm}{dd}/{time}{rand:6}"", /* 上传保存路径,可以自定义保存路径和文件名格式 */
    ""videoUrlPrefix"": """", /* 视频访问路径前缀 */
    ""videoMaxSize"": 102400000, /* 上传大小限制，单位B，默认100MB */
    ""videoAllowFiles"": [
        "".flv"", "".swf"", "".mkv"", "".avi"", "".rm"", "".rmvb"", "".mpeg"", "".mpg"",
        "".ogg"", "".ogv"", "".mov"", "".wmv"", "".mp4"", "".webm"", "".mp3"", "".wav"", "".mid""], /* 上传视频格式显示 */

    /* 上传文件配置 */
    ""fileActionName"": ""uploadfile"", /* controller里,执行上传视频的action名称 */
    ""fileFieldName"": ""upfile"", /* 提交的文件表单名称 */
    ""filePathFormat"": ""upload/file/{yyyy}{mm}{dd}/{time}{rand:6}"", /* 上传保存路径,可以自定义保存路径和文件名格式 */
    ""fileUrlPrefix"": """", /* 文件访问路径前缀 */
    ""fileMaxSize"": 51200000, /* 上传大小限制，单位B，默认50MB */
    ""fileAllowFiles"": [
        "".png"", "".jpg"", "".jpeg"", "".gif"", "".bmp"",
        "".flv"", "".swf"", "".mkv"", "".avi"", "".rm"", "".rmvb"", "".mpeg"", "".mpg"",
        "".ogg"", "".ogv"", "".mov"", "".wmv"", "".mp4"", "".webm"", "".mp3"", "".wav"", "".mid"",
        "".rar"", "".zip"", "".tar"", "".gz"", "".7z"", "".bz2"", "".cab"", "".iso"",
        "".doc"", "".docx"", "".xls"", "".xlsx"", "".ppt"", "".pptx"", "".pdf"", "".txt"", "".md"", "".xml""
    ], /* 上传文件格式显示 */

    /* 列出指定目录下的图片 */
    ""imageManagerActionName"": ""listimage"", /* 执行图片管理的action名称 */
    ""imageManagerListPath"": ""upload/image"", /* 指定要列出图片的目录 */
    ""imageManagerListSize"": 20, /* 每次列出文件数量 */
    ""imageManagerUrlPrefix"": """", /* 图片访问路径前缀 */
    ""imageManagerInsertAlign"": ""none"", /* 插入的图片浮动方式 */
    ""imageManagerAllowFiles"": ["".png"", "".jpg"", "".jpeg"", "".gif"", "".bmp""], /* 列出的文件类型 */

    /* 列出指定目录下的文件 */
    ""fileManagerActionName"": ""listfile"", /* 执行文件管理的action名称 */
    ""fileManagerListPath"": ""upload/file"", /* 指定要列出文件的目录 */
    ""fileManagerUrlPrefix"": """", /* 文件访问路径前缀 */
    ""fileManagerListSize"": 20, /* 每次列出文件数量 */
    ""fileManagerAllowFiles"": [
        "".png"", "".jpg"", "".jpeg"", "".gif"", "".bmp"",
        "".flv"", "".swf"", "".mkv"", "".avi"", "".rm"", "".rmvb"", "".mpeg"", "".mpg"",
        "".ogg"", "".ogv"", "".mov"", "".wmv"", "".mp4"", "".webm"", "".mp3"", "".wav"", "".mid"",
        "".rar"", "".zip"", "".tar"", "".gz"", "".7z"", "".bz2"", "".cab"", "".iso"",
        "".doc"", "".docx"", "".xls"", "".xlsx"", "".ppt"", "".pptx"", "".pdf"", "".txt"", "".md"", "".xml""
    ] /* 列出的文件类型 */

}";
            return JObject.Parse(json);
        }

        public static JObject Items
        {
            get
            {
                if (noCache || _Items == null)
                {
                    _Items = BuildItems();
                }
                return _Items;
            }
        }
        private static JObject _Items;


        public static T GetValue<T>(string key)
        {
            return Items[key].Value<T>();
        }

        public static String[] GetStringList(string key)
        {
            return Items[key].Select(x => x.Value<String>()).ToArray();
        }

        public static String GetString(string key)
        {
            return GetValue<String>(key);
        }

        public static int GetInt(string key)
        {
            return GetValue<int>(key);
        }
    }
}

