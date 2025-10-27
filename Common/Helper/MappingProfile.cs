using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RMS.Common.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}
