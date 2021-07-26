using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace WindowsApplication.Utility
{

    public class HtmlObject
    {
        public WebClient Client { get; }
        public string R_Uri { set; get; }
        public string W_Uri { set; get; }
        public string HtmlString { set; get; }

        public List<string> HtmlList;

        public HtmlObject()
        {
            Client = new WebClient();
            HtmlList = new List<string>();
        }

        public HtmlObject(string r_uri, string w_uri)
        {
            Client = new WebClient();
            HtmlList = new List<string>();

            R_Uri = r_uri;
            W_Uri = w_uri;
        }

    }



    public static class HtmlOperator
    {
        static Stream postStream;

        // 构造函数


        /// <summary>
        /// 将指定uri的html的内容读取到string和List<string>中
        /// </summary>
        /// <param name="htmlData">html对象</param>
        /// <returns>html数据存储对象</returns>
        public static HtmlObject Read(HtmlObject htmlData)
        {

            Stream data = htmlData.Client.OpenRead(htmlData.R_Uri);
            StreamReader reader = new StreamReader(data);


            // 读取至string
            string htmlText = reader.ReadToEnd();
            htmlData.HtmlString = htmlText;

            data.Close();
            reader.Close();


            // 按行存储至List<string>
            string curString = "";
            foreach (var s in htmlData.HtmlString)
            {
                curString += s;
                if (s == '\n')
                {
                     htmlData.HtmlList.Add(curString);
                    curString = "";
                }
            }

            return htmlData;
        }


        /// <summary>
        /// 将html内容以string写入
        /// </summary>
        /// <param name="uri">uri</param>
        /// <param name="htmlText">html内容</param>
        public static void Write(HtmlObject htmlData)
        {
            string postData = htmlData.HtmlString;
            byte[] postArray = Encoding.UTF8.GetBytes(postData);

            try
            {
                // W_Uri有值
                if (htmlData.W_Uri != null || htmlData.W_Uri != "")
                {
                    postStream = htmlData.Client.OpenWrite(htmlData.W_Uri);
                    postStream.Write(postArray, 0, postArray.Length);
                    postStream.Close();
                }
            }
            catch(Exception)
            {

            }
            
        }


        public static void Write(HtmlObject htmlData, string uri)
        {
            string postData = htmlData.HtmlString;
            byte[] postArray = Encoding.UTF8.GetBytes(postData);

            try
            {
                postStream = htmlData.Client.OpenWrite(uri);
                postStream.Write(postArray, 0, postArray.Length);
                postStream.Close();
            }
            catch (Exception)
            {

            }
        }



        /// <summary>
        /// 查询html指定行，需将html内容按行存储后调用
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string QueryRow(HtmlObject htmlData, int row)
        {
            string targetText = "";
            if (htmlData.HtmlList.Count == 0)
                return "The htmlList is empty!";

            if (row > htmlData.HtmlList.Count - 1)
                row = htmlData.HtmlList.Count - 1;
            else if (row < 0)
                row = 0;

            targetText = htmlData.HtmlList[row];
            return targetText;
        }


    }
}
