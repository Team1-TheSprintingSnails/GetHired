using System;
using System.Linq;
using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;

namespace GetHired.Services.Services
{
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPasswordHashGenerator hashGenerator;

        private readonly string[] passwordSalts =
        {
            @"GRWwnK/kFIua6YcTd/MmqEiMtZB7t7M39gcrR4iEkFo=",
            @"/L8N25twvtkOtgGArYYD3did2Gs05H4swONRRSYVSWQ=",
            @"IW819FwPvdKLvRRAitAl0O7KJWRIFQvNLIO8gYN8pfI="
        };

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHashGenerator hashGenerator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.hashGenerator = hashGenerator;
        }

        public UserModel GetByEmail(string email)
        {
            if (email == null) return null;

            var user = this.unitOfWork
                .UserRepository
                .GetByEmail(email);

            return this.mapper.Map<UserModel>(user);
        }

        public bool UpdateUser(UserModel userModel)
        {
            if (userModel == null) return false;

            var user = this.mapper.Map<User>(userModel);

            try
            {
                this.unitOfWork.UserRepository.Update(user);
                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserModel GetById(int id)
        {
            var user = this.unitOfWork.UserRepository
                .GetById(id);

            return this.mapper.Map<UserModel>(user);
        }

        public bool DeleteUser(int id)
        {

            var user = this.unitOfWork.UserRepository
                .GetById(id);

            if (user == null) return false;

            try
            {
                this.unitOfWork.UserRepository
                    .Delete(user);

                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            if (email == null) return false;
            if (oldPassword == null) return false;
            if (newPassword == null) return false;

            var user = this.unitOfWork.UserRepository
                .GetByEmail(email);

            if (user == null) return false;

            var passwordIsMismached = this.passwordSalts
                .All(salt =>
                {
                    var paswordHash = this.hashGenerator.GenerateSaltedHash(oldPassword, salt);
                    return paswordHash != user.PasswordHash;
                });

            if (passwordIsMismached) return false;

            var random = new Random();
            var randomIndex = random.Next(0, this.passwordSalts.Length);
            var randomSalt = this.passwordSalts[randomIndex];

            try
            {
                this.unitOfWork.UserRepository
                    .Attach(user);

                user.PasswordHash = this.hashGenerator
                    .GenerateSaltedHash(newPassword, randomSalt);

                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RegisterNewUser(UserRegistrationModel userRegistrationModel)
        {
            if (userRegistrationModel == null) return false;

            var user = this.mapper.Map<User>(userRegistrationModel);
            
            this.unitOfWork.UserRepository
                .Attach(user);

            var random = new Random();
            var randomIndex = random.Next(0, this.passwordSalts.Length);
            var randomSalt = this.passwordSalts[randomIndex];
            var userPassword = userRegistrationModel.Password;

            try
            {
                user.PasswordHash = this.hashGenerator
                    .GenerateSaltedHash(userPassword, randomSalt);

                this.unitOfWork.UserRepository
                    .Insert(user);

                this.unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
