using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameGourmet.modal
{
  public class Prato
  {
    public string Nome { get; set; }
    public string Tipo { get; set; }

    public Prato(string nome, string tipo)
    {
      Nome = nome;
      Tipo = tipo;
    }
  }
}