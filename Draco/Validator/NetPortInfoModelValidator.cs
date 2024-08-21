using Draco.Models.TCP;

using FluentValidation;

using One.Core.Helpers.DataProcessHelpers;

using System.Text.RegularExpressions;

namespace Draco.Validator
{
    public class NetPortInfoModelValidator : AbstractValidator<NetPortInfoModel>
    {
        public NetPortInfoModelValidator()
        {
            //this.CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.IPAddress).Must(ValidIP).WithMessage("IP地址不合法");
            RuleFor(x => x.NetMask).Must(ValidIP).WithMessage("掩码地址不合法");
            RuleFor(x => x.NetGateWayAddress).Must(ValidIP).WithMessage("网关地址不合法");
        }

        private bool ValidIP(string ip)
        {
            return !string.IsNullOrEmpty(ip) && Regex.IsMatch(ip, RegexHelper.IPv4AddressRegex);
        }
    }
}