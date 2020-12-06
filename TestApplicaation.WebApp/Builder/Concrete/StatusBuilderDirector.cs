using TestApplication.Builder.Abstract;
using TestApplication.Common.Dto.UserDtos;

namespace TestApplication.Builder.Concrete
{
    public class StatusBuilderDirector
    {

        private StatusBuilder _statusBuilder;
        public StatusBuilderDirector(StatusBuilder builder)
        {
            this._statusBuilder = builder;

        }

        public Status GenerateStatus(UserDto activeUser,string roles)
        {
            return _statusBuilder.GenerateStatus(activeUser, roles);
        }
    }
}
