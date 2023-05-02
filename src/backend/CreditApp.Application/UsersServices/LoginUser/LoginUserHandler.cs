using CreditApp.Domain;
using CreditApp.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.UsersServices.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IRepository repository;
        private readonly ISecurity security;

        public LoginUserHandler(IRepository repository, ISecurity security)
        {
            this.repository = repository;
            this.security = security;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user;
            string encryptPassword;
            string token;

            if (!repository.Exists<User>(x => x.Email == request.Email))
                throw new Exception("El usuario no se encuentra registrado");

            user = await repository.Get<User>(x => x.Email == request.Email);

            //encryptPassword = security.EncryptPassword(request.Password);

            //if (user.Password != encryptPassword)
            //throw new Exception("La contraseña es incorrecta");

            token = security.CreateToken(user.Id.ToString(), user.Names, user.Email, "Admin");
            user.TypeUser = TypeUser.Admin;

            user.Token = token;

            //repository.Update<User>(user);
            //await repository.Commit();

            return user.Token;
        }
    }
}