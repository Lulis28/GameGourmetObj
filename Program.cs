using System.IO.Compression;
using GameGourmet.modal;

namespace GameGourmet;

class Program
{

  private static bool Resposta;

  static void Main(string[] args)
  {

    List<Prato> pratosMassa = new List<Prato>();
    pratosMassa.Add(new Prato("Lasanha", "Massa"));

    List<Prato> pratosNaoMassa = new List<Prato>();
    pratosNaoMassa.Add(new Prato("Bolo de Chocolate", ""));

    // Lógica do jogo
    bool jogarNovamente = true;

    Console.WriteLine("Bem-vindo ao Jogo Gourmet!");
    Console.WriteLine("Vamos começar!");
    Console.WriteLine("Pressione qualquer tecla para começar...");
    Console.ReadKey();
    Console.Clear();

    while (jogarNovamente)
    {

      IniciarJogo();

      Console.WriteLine($"O prato que você pensou é massa ? digite S ou N");
      Resposta = RetornaRespostaFormatoCorreto(Console.ReadLine().ToLower());

      if (Resposta)
      {
        AdivinharPrato(pratosMassa);
      }
      else
      {
        AdivinharPrato(pratosNaoMassa);
      }

    }
  }

  public static bool RetornaRespostaFormatoCorreto(string resposta)
  {
    if (resposta == "s")
      return true;

    return false;
  }

  public static void AdivinharPrato(List<Prato> pratos)
  {

    int contador = 0;
    int contadorPratos = pratos.Count - 1;

    for (contador = contadorPratos; contador > 0; contador--)
    {
      Resposta = PerguntarPrato(pratos, contador, true);

      if (Resposta)
      {
        Resposta = PerguntarPrato(pratos, contador, false);

        if (Resposta)
        {
          Acertei();
          break;
        }
        else if (!Resposta && contador == pratos.Count - 1)
        {
          AddPrato(pratos, contador);
          break;
        }
      }
    }

    if (contador == 0)
    {
      Resposta = PerguntarPrato(pratos, contador, false);

      if (Resposta)
      {
        Acertei();
        return;
      }

      AddPrato(pratos, contador);
    }
  }

  public static bool PerguntarPrato(List<Prato> pratos, int contador, bool tipo)
  {
    if (tipo)
    {
      Console.WriteLine($"O prato que você pensou é {pratos[contador].Tipo}? digite S ou N");
    }
    else
    {
      Console.WriteLine($"O prato que você pensou é {pratos[contador].Nome}? digite S ou N");
    }

    return RetornaRespostaFormatoCorreto(Console.ReadLine().ToLower());
  }

  public static void Acertei()
  {
    Console.WriteLine("Acertei de novo!");
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
  }

  public static void IniciarJogo()
  {
    Console.WriteLine("Pense em um prato e responda com s para sim ou n para não às perguntas.");
    Console.WriteLine("Pressione qualquer tecla para começar...");
    Console.ReadKey();
  }

  public static void AddPrato(List<Prato> pratos, int contador)
  {
    pratos.Add(CriaPrato(pratos, contador));
  }

  public static Prato CriaPrato(List<Prato> pratos, int ordemPrato)
  {

    Console.WriteLine("Qual prato você pensou?");
    string nome = Console.ReadLine();

    string tipoRespostaComparacao = pratos[ordemPrato].Tipo == "" ? pratos[ordemPrato].Nome : pratos[ordemPrato].Tipo;

    Console.WriteLine($"{nome} é __________ Mas {tipoRespostaComparacao} não");
    string caracteristica = Console.ReadLine();
    Console.WriteLine("Pressione qualquer tecla para começar...");
    Console.ReadKey();
    Console.Clear();

    return new Prato(nome, caracteristica);

  }

}
