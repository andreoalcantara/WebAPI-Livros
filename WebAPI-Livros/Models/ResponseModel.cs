﻿using WebAPI_Livros.Migrations;

namespace WebAPI_Livros.Models
{
    public class ResponseModel<T>
    {
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    }
}
