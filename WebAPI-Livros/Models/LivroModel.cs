﻿using WebAPI_Livros.Models;

namespace WebAPI_Livros.models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; }

        public static implicit operator LivroModel(ResponseModel<LivroModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
