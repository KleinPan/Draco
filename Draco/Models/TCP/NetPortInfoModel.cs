using Draco.Validator;

using Newtonsoft.Json;

using System;
using System.Linq;

namespace Draco.Models.TCP
{
    [JsonObject]
    public class NetPortInfoModel
    {
        public NetPortInfoModel()
        {
            validator = new NetPortInfoModelValidator();
        }

        private NetPortInfoModelValidator validator;

        [Newtonsoft.Json.JsonIgnore]
        public string Error
        {
            get
            {
                var results = validator.Validate(this);
                if (results != null && results.Errors.Any())
                {
                    var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                    return errors;
                }

                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (validator == null)
                {
                    validator = new NetPortInfoModelValidator();
                }
                var firstOrDefault = validator.Validate(this)
                    .Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                return firstOrDefault?.ErrorMessage;
            }
        }

        public string IPAddress { get; set; }

        public string NetMask { get; set; }

        public string NetGateWayAddress { get; set; }
    }
}
