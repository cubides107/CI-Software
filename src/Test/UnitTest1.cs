using System.Security.Claims;
using CreditApp.Application.ProductServices.GetProduct;
using CreditApp.Application.ProductServices.RegisterProduct;
using CreditApp.Application.UsersServices.LoginUser;
using CreditApp.Application.UsersServices.RegisterUser;
using MarketPlace.Domain;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.UserEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace Test;
[TestClass]
public class Tests
{
    private readonly Mock<IRepository> userRepository;
    private readonly Mock<ISecurity> userSecurity;
    private readonly Mock<IMapObject> mapObject;

    public Tests()
    {
        userRepository = new Mock<IRepository>();
        userSecurity = new Mock<ISecurity>();
        mapObject = new Mock<IMapObject>();
    }
    
    [SetUp]
    public void Setup()
    {
    }

    [TestMethod]
    public async Task LoginUserTest()
    {
        var newToken = "jssuisjsuj8983j45.";
        
        var request = new LoginUserCommand()
        {
            Email = "cristian@gmail.com",
            Password = "234234",
        };
        
        var password = "julian10";
        var mail = "cristhiancubides84@gmail.com";
        var cancelationToken = new CancellationToken();
        var token = "jsusjsuj8983j45.";
        var encryptPassword = "sfasdfwerfsdf";
        var id = "1";
        var name = "Julian";
        var lastName = "Cubides";
        var phone = "3138989123";
        var address = "Carrera 1 Este #33-34";

        User user = new User("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        User userUpdate = new("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        userUpdate.Token = token;
        
        userRepository.Setup(x => x.Exists<User>(x => x.Email == request.Email))
            .Returns(true)
            .Verifiable();
        
        userRepository.Setup(x => x.Get<User>(x => x.Email == request.Email))
            .ReturnsAsync(user)
            .Verifiable();

        userSecurity.Setup(x => x.CreateToken(user.Id.ToString(), user.Names, user.Email, "Admin"))
            .Returns(newToken)
            .Verifiable();

        userSecurity.Setup(x=>x.EncryptPassword(request.Password))
            .Returns(encryptPassword)
            .Verifiable();


        userRepository.Setup(x => x.Update(user));
        userRepository.Setup(x=>x.Commit());

        var loginUserHandler = new LoginUserHandler(userRepository.Object,userSecurity.Object);

        var tokenResult = await loginUserHandler.Handle(request,cancelationToken);
        
        Assert.That(tokenResult, Is.EqualTo(newToken));

       // Assert.Pass();
    }
    
    [TestMethod]
    public async Task RegisterProduct()
    {
        var newToken = "jssuisjsuj8983j45.";
        List<Claim> claims = new();

        var userId = 1;
        var request = new RegisterProductCommand()
        {
            Claims = claims,
            Description = "Producto de test",
            Reference = "234234",
            Price = 234234,
            Stock = 2
        };

        Product product = new Product("Test",234,"dsfsdf",2,"sdfsdf");
        GetProductDTO getProductDto = new GetProductDTO();
        
        var password = "julian10";
        var mail = "cristhiancubides84@gmail.com";
        var cancelationToken = new CancellationToken();
        var token = "jsusjsuj8983j45.";
        var encryptPassword = "sfasdfwerfsdf";
        var id = "1";
        var name = "Julian";
        var lastName = "Cubides";
        var phone = "3138989123";
        var address = "Carrera 1 Este #33-34";

       
        User user = new User("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        user.Products = new List<Product>();
        User userUpdate = new("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        userUpdate.Token = token;
       
        userSecurity.Setup(x=>x.GetClaim(claims,ISecurity.USERID))
            .Returns("1")
            .Verifiable();
        
        userRepository.Setup(x => x.Get<User>(user1 => user1.Id == userId))
            .ReturnsAsync(user)
            .Verifiable();

        mapObject.Setup(x => x.Map<Product, GetProductDTO>(product))
            .Returns(getProductDto)
            .Verifiable();
        
        var loginUserHandler = new RegisterProductHandler(userRepository.Object,mapObject.Object, userSecurity.Object);

        var tokenResult = await loginUserHandler.Handle(request,cancelationToken);
        
        Assert.That(tokenResult == null);

        // Assert.Pass();
    }
    
    /// <summary>
    /// Se comprueba cuando el usuario no se encuentra registrado
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public async Task NotFoundUser()
    {
        var loginUserHandler = new LoginUserHandler(userRepository.Object, userSecurity.Object);
        
        var request = new LoginUserCommand()
        {
            Email = "cristian@gmail.com",
            Password = "234234",
        };

        await loginUserHandler.Handle(request, new CancellationToken());
    }
    
    /// <summary>
    /// Se comprueba que la contraseña es incorrecta
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public async Task PasswordIncorrect()
    {
        var loginUserHandler = new LoginUserHandler(userRepository.Object, userSecurity.Object);
        
        var request = new LoginUserCommand()
        {
            Email = "cristian@gmail.com",
            Password = "234234",
        };
        
        User user = new User("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        var newToken = "jsusjsuj8983j45.";
        var encryptPassword = "sfasdfwerfsdf34545";
        
        userRepository.Setup(x => x.Exists<User>(x => x.Email == request.Email))
            .Returns(true)
            .Verifiable();
        
        userRepository.Setup(x => x.Get<User>(x => x.Email == request.Email))
            .ReturnsAsync(user)
            .Verifiable();

        userSecurity.Setup(x => x.CreateToken(user.Id.ToString(), user.Names, user.Email, "Admin"))
            .Returns(newToken)
            .Verifiable();

        userSecurity.Setup(x=>x.EncryptPassword(request.Password))
            .Returns(encryptPassword)
            .Verifiable();
        await loginUserHandler.Handle(request, new CancellationToken());
    }

    [TestMethod]
    public async Task RegisterUser()
    {
        var newToken = "jssuisjsuj8983j45.";
        
        var request = new RegisterUserCommand()
        {
            Email = "davison@gmail.com",
            LastNames = "Peña",
            Names = "Davison Castelblanco",
            Password = "234234",
        };
        
        var password = "julian10";
        var mail = "cristhiancubides84@gmail.com";
        var cancelationToken = new CancellationToken();
        var token = "jsusjsuj8983j45.";
        var encryptPassword = "sfasdfwerfsdf";
        var id = "1";
        var name = "Julian";
        var lastName = "Cubides";
        var phone = "3138989123";
        var address = "Carrera 1 Este #33-34";

        User user = new User("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        User userUpdate = new("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        userUpdate.Token = token;
        
        userRepository.Setup(x => x.Exists<User>(x => x.Email == request.Email))
            .Returns(false)
            .Verifiable();
        
        userRepository.Setup(x => x.Get<User>(x => x.Email == request.Email))
            .ReturnsAsync(user)
            .Verifiable();

        userSecurity.Setup(x => x.CreateToken(user.Id.ToString(), user.Names, user.Email, "Admin"))
            .Returns(newToken)
            .Verifiable();

        userSecurity.Setup(x=>x.EncryptPassword(request.Password))
            .Returns(encryptPassword)
            .Verifiable();

        userRepository.Setup(x => x.Save(user));
        userRepository.Setup(x=>x.Commit());
        

        RegisterUserHandler registerUser = new RegisterUserHandler(userRepository.Object,userSecurity.Object);
        var dto = await registerUser.Handle(request, cancelationToken);
        Assert.That(dto, Is.EqualTo(0));
    }
    
    [TestMethod]
    [ExpectedException(typeof(Exception))] 
    public async Task RegisterUser_ExceptionUser()
    {
        var newToken = "jssuisjsuj8983j45.";
        
        var request = new RegisterUserCommand()
        {
            Email = "davison@gmail.com",
            LastNames = "Peña",
            Names = "Davison Castelblanco",
            Password = "234234",
        };
        
        var password = "julian10";
        var mail = "cristhiancubides84@gmail.com";
        var cancelationToken = new CancellationToken();
        var token = "jsusjsuj8983j45.";
        var encryptPassword = "sfasdfwerfsdf";
        var id = "1";
        var name = "Julian";
        var lastName = "Cubides";
        var phone = "3138989123";
        var address = "Carrera 1 Este #33-34";

        User user = new User("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        User userUpdate = new("Julian cubides","cubides","cristian@gmailcom","sfasdfwerfsdf");
        userUpdate.Token = token;
        
        userRepository.Setup(x => x.Exists<User>(x => x.Email == request.Email))
            .Returns(true)
            .Verifiable();
        
        userRepository.Setup(x => x.Get<User>(x => x.Email == request.Email))
            .ReturnsAsync(user)
            .Verifiable();

        userSecurity.Setup(x => x.CreateToken(user.Id.ToString(), user.Names, user.Email, "Admin"))
            .Returns(newToken)
            .Verifiable();

        userSecurity.Setup(x=>x.EncryptPassword(request.Password))
            .Returns(encryptPassword)
            .Verifiable();

        userRepository.Setup(x => x.Save(user));
        userRepository.Setup(x=>x.Commit());
        

        RegisterUserHandler registerUser = new RegisterUserHandler(userRepository.Object,userSecurity.Object);
        await registerUser.Handle(request, cancelationToken);
    }
    
    
    
}