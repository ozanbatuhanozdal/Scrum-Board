using TestApplication.Builder.Concrete;
using TestApplication.Common.Dto;
using TestApplication.Common.Dto.UserDtos;

namespace TestApplication.Builder.Abstract
{
    public abstract class StatusBuilder
    {
        public abstract Status GenerateStatus(UserDto userDto, string roles);
        

    }
}
