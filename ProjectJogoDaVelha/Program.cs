char[,] matvelha = {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};
char esc = ' ';
bool fim = false;
int jogador = 0;

do
{
    //Impressão da matriz
    for (int l = 0; l < matvelha.GetLength(0); l++)
    {
        for (int c = 0; c < matvelha.GetLength(1); c++)
        {
            Console.Write("|" + matvelha[l, c] + "|");
        }
        Console.WriteLine();
    }
    //Verificando qual jogador deve jogar
    if (jogador % 2 == 0)
    {
        Console.Write("Escolha jogador X: ");
        esc = char.Parse(Console.ReadLine());
    }
    else
    {
        Console.Write("Escolha jogador O: ");
        esc = char.Parse(Console.ReadLine());
    }
    if (VerificarDigito(esc))
    {
        VerificarLugar(esc);
        Console.WriteLine("Digete qualquer tecla para avançar");
        Console.ReadLine();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Digito inválido! Aperte qualquer tecla para continuar.");
        Console.ReadLine();
    }
    Console.Clear();

} while (!fim);


//Verificando se o espaço solicitado esta disponivel
bool VerificarLugar(char esc)
{
    bool disponivel = false;
    for(int l = 0; l < matvelha.GetLength(0); l++)
    {
        for(int c = 0; c < matvelha.GetLength(1);c++)
        {
            if (esc == matvelha[l, c])
            {
                disponivel = true;
                AtribuirEscolha();
                break;
            }
        }
    }
    return disponivel;
}
//Verificando se o digito é o solicitado
bool VerificarDigito(char esc)
{
    bool verifica = false;
    for(int l = 0;l < matvelha.GetLength(0); l++)
    {
        for(int c = 0; c < matvelha.GetLength(1); c++)
        {
            if (esc.Equals(matvelha[l, c]))
            {
                verifica = true;
                break;
            }
        }
    }

    return verifica;
}
//Atribui o "Valor" desejado na matriz
void AtribuirEscolha()
{
    if (jogador % 2 == 0)
    {
        for (int l = 0; l < matvelha.GetLength(0); l++)
        {
            for (int c = 0; c < matvelha.GetLength(1); c++)
            {
                if (esc.Equals(matvelha[l, c]))
                {
                    matvelha[l, c] = 'X';
                    jogador += 1;
                }
            }
        }
    }
    else
    {
        for (int l = 0; l < matvelha.GetLength(0); l++)
        {
            for (int c = 0; c < matvelha.GetLength(1); c++)
            {
                if (esc.Equals(matvelha[l, c]))
                {
                    matvelha[l, c] = 'O';
                    jogador += 1;
                }
            }
        }
    }

}











//void ImprimirTabu(char pos)
//{
//    for (int l = 0; l < matvelha.GetLength(0); l++)
//    {
//        for (int c = 0; c < matvelha.GetLength(1); c++)
//        {
//            Console.Write("|" + matvelha[l, c] + "|");

//        }
//        Console.WriteLine();
//    }
//}
