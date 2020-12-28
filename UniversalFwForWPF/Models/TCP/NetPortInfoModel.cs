using System;
using System.ComponentModel;
using System.Linq;

using Newtonsoft.Json;

using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Validator;

namespace UniversalFwForWPF.Models.TCP
{
    [JsonObject]
    public class NetPortInfoModel : ReactiveUI.ReactiveObject, IDataErrorInfo
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

        [Reactive] public string IPAddress { get; set; }

        [Reactive] public string NetMask { get; set; }

        [Reactive] public string NetGateWayAddress { get; set; }
    }
}
