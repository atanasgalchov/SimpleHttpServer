

using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SharpStoreData
{

   
    using System.IO;
    using System.Text;
   

        public static class PageLoader
        {
            private static SharpStoreContext context;
            public static string GetProductsPage(string content)
            {
            context = new SharpStoreContext();
              
                

                StringBuilder sb = new StringBuilder();
                var allLines = File.ReadLines("../../content/Products.html");

                foreach (var line in allLines)
                {
                    if (!line.Contains("prdoducts-items"))
                    {
                        sb.AppendLine(line);
                    }
                    else
                    {
                        break;
                    }
                }
                sb.AppendLine("<ul class=\"row container container-fluid list-group prdoducts-items\">");
                if (string.IsNullOrEmpty(content))
                {
                foreach (var knife in context.Knifes)
                {
                    sb.AppendLine("<li class=\"col-lg-3 list-group-item\" id=\"article\">");
                    sb.AppendLine(
                        $"<img src=\"{knife.ImgURL}\"  alt=\"Sharp4023\" id=\"Products\">");
                    sb.AppendLine("<content>");
                    sb.AppendLine($"<h1>{knife.Name}</h1>");
                    sb.AppendLine("<br>");
                    sb.AppendLine($"<h2>{knife.Price}</h2>");
                    sb.AppendLine("<br>\r\n          <input type=\"submit\" value=\"Buy Now\" name=\"BuySharp\" class=\"btn btn-primary\">\r\n          </content>\r\n      </li>");

                }
            }
                else
                {
                
                var keyWord = WebUtility.UrlDecode(content).Split('&').FirstOrDefault().Split('=').LastOrDefault();
                    if (context.Knifes.Where(k => k.Name.Contains(keyWord)).Count()==0)
                    {
                        sb.AppendLine("<h3>Do not fine knifes</h3>");
                    }
                    else
                    {
                    foreach (var knife in context.Knifes.Where(k => k.Name.Contains(keyWord)))
                    {
                        sb.AppendLine("<li class=\"col-lg-3 list-group-item\" id=\"article\">");
                        sb.AppendLine(
                            $"<img src=\"{knife.ImgURL}\"  alt=\"Sharp4023\" id=\"Products\">");
                        sb.AppendLine("<content>");
                        sb.AppendLine($"<h1>{knife.Name}</h1>");
                        sb.AppendLine("<br>");
                        sb.AppendLine($"<h2>{knife.Price}</h2>");
                        sb.AppendLine("<br>\r\n          <input type=\"submit\" value=\"Buy Now\" name=\"BuySharp\" class=\"btn btn-primary\">\r\n          </content>\r\n      </li>");

                    }
                }
            
            }

                sb.AppendLine("</ul>");



                bool isWrite = false;
                foreach (var line in allLines)
                {

                    if (isWrite)
                    {
                        sb.AppendLine(line);
                    }
                    if (line.Contains("botom-side"))
                    {
                        sb.AppendLine(line);
                        isWrite = true;
                    }
                }

                return sb.ToString();
            }


        }
    

}
