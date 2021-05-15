using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JCompare
{
    public class JsonCompare
    {
        private string _soruceJsonData { get; set; }
        private string _destinationJsonData { get; set; }
        public JsonCompare(string soruceJsonData, string destinationJsonData)
        {
            _soruceJsonData = soruceJsonData;
            _destinationJsonData = destinationJsonData;
        }
        public string Compare()
        {
            string returnReply = "Matching";
            var soruce = JToken.Parse(_soruceJsonData);
            var destination = JToken.Parse(_destinationJsonData);

            List<string> sourceData = GetListOfJToken(soruce);
            List<string> destinationData = GetListOfJToken(destination);


            foreach (var sourceItem in sourceData)
            {
                bool isMatch = false;

                foreach (var destinationItem in destinationData)
                {
                    if (sourceItem == destinationItem)
                    {
                        isMatch = true;
                        break;
                    }
                }

                if (!isMatch)
                {
                    returnReply = "Not Matching";
                    break;
                }
            }
            return returnReply;
        }

        private List<string> GetListOfJToken(JToken jTokenData)
        {
            List<string> listOfData = new List<string>();
            foreach (object item in jTokenData.Children())
            {
                listOfData.Add(item.ToString());
            }
            return listOfData;
        }
    }
}