﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MobileShop.Model;
using MobileShop.Model.Models;
using MobileShop.Model.Requests;

namespace MobileShop.WebAPI.Services
{
    public class KlijentiService : IKlijentiService
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public KlijentiService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Models.Klijenti Authenticiraj(string username, string pass)
        {
            var user = _context.Klijenti.FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var hashedPass = GenerateHash(user.LozinkaSalt, pass);

                if (hashedPass == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Models.Klijenti>(user);
                }
            }

            return null;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }


        public List<Klijenti> Get(KlijentiSearchRequest search)
        {
            var query = _context.Klijenti.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(search.Ime));
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(search.Prezime));
            }

           

            var list = query.ToList();

            return _mapper.Map<List<Model.Models.Klijenti>>(list);

        }

        public Klijenti GetById(int id)
        {
            var entity = _context.Klijenti.Find(id);

            return _mapper.Map<Model.Models.Klijenti>(entity);

        }
        public void Insert(KlijentiInsertRequest request)
        {
            Model.Database.Klijenti entity = _mapper.Map<Model.Database.Klijenti>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Klijenti.Add(entity);
            _context.SaveChanges();

            

            _context.SaveChanges();



        }

        public void Update(int id, KlijentiInsertRequest request)
        {
            var entity = _context.Klijenti.Find(id);
            _context.Klijenti.Attach(entity);
            _context.Klijenti.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _mapper.Map(request, entity);

            _context.SaveChanges();


        }
    }
}
