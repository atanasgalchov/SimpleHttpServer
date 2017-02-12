

using System;
using System.Net;
using System.Text.RegularExpressions;
using SharpStoreModels.Models;

namespace SharpStoreData
{
  public  class DataProvider
  {
      private SharpStoreContext context;

      public DataProvider()
      {
            this.context = new SharpStoreContext();
      }

      public void AddToDatabase(string url,string content)
      {
          string[] tokens = WebUtility.UrlDecode(content).Split('&');
        
          if (Regex.IsMatch(url, @"^/Contacts"))
          {
              if (tokens.Length < 3)
              {
                  throw new ArgumentException();
              }
              var message = new Message();
              message.Sender = tokens[0].Split('=')[1];
              message.Subject = tokens[1].Split('=')[1];
              message.Content = tokens[2].Split('=')[1];
              context.Messages.Add(message);
              context.SaveChanges();
          }

      }
    }
}
