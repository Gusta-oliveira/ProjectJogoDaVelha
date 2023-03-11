char[,] matvelha = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
char esc = ' ';
bool fim = false, vitoria = false, velha = false;
int jogador = 0, rodada = 5;

ImprimirMatriz();
do
{
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
    //Chamando e verificando se o digito esta correto.
    if (VerificarDigito(esc))
    {


        VerificarLugar(esc);

    }
    else if (!VerificarDigito(esc))
    {
        Console.WriteLine("Digito incorreto. Informe outro.");
        Console.ReadLine();
    }
    rodada++;
} while (!fim);
//Impressão da matriz
void ImprimirMatriz()
{
    Console.Clear();
    for (int l = 0; l < matvelha.GetLength(0); l++)
    {
        for (int c = 0; c < matvelha.GetLength(1); c++)
        {
            Console.Write("|" + matvelha[l, c] + "|");
        }
        Console.WriteLine();
    }
}

//Verificando se o espaço solicitado esta disponivel
bool VerificarLugar(char esc)
{
    bool disponivel = false;
    for (int l = 0; l < matvelha.GetLength(0); l++)
    {
        for (int c = 0; c < matvelha.GetLength(1); c++)
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
    for (int l = 0; l < matvelha.GetLength(0); l++)
    {
        for (int c = 0; c < matvelha.GetLength(1); c++)
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
    for (int l = 0; l < matvelha.GetLength(0); l++)
    {
        for (int c = 0; c < matvelha.GetLength(1); c++)
        {
            if (esc.Equals(matvelha[l, c]))
            {
                if (jogador % 2 == 0)
                {
                    matvelha[l, c] = 'X';
                    ImprimirMatriz();
                    if (CondicaoVitoria())
                    {
                        Console.WriteLine("O jogo acabou! Vencedor jogador X.");
                        fim = true;
                        Console.ReadLine();
                    }
                }
                else if (jogador % 2 == 1)
                {
                    matvelha[l, c] = 'O';
                    ImprimirMatriz();
                    if (CondicaoVitoria())
                    {
                        Console.WriteLine("O jogo acabou! Vencedor jogador O.");
                        fim = true;
                        Console.ReadLine();
                    }
                }
                else if(esc != matvelha[l, c])
                {
                    Console.WriteLine("VELHA!!!!!");
                    fim = true;
                }
                jogador += 1;
            }
        }
    }
}

bool CondicaoVitoria()
{
    if (rodada > 4)
    {
        for (int l = 0; l < matvelha.GetLength(0); l++)
        {
            for (int c = 0; c < matvelha.GetLength(1); c++)
            {
                //Se as linhs forem iguais
                if ((matvelha[l, 0] == matvelha[l, 1]) && (matvelha[l, 1] == matvelha[l, 2]))
                {
                    vitoria = true;
                    break;
                }
                //Colunas iguais
                else if ((matvelha[0, c] == matvelha[1, c]) && (matvelha[1, c] == matvelha[2, c]))
                {
                    vitoria = true;
                    break;

                }
                //Diagonal principal
                else if ((matvelha[0, 0] == matvelha[1, 1]) && (matvelha[1, 1] == matvelha[2, 2]))
                {
                    vitoria = true;
                }
                //Diagonal secundária
                else if ((matvelha[0, 2] == matvelha[1, 1]) && (matvelha[1, 1] == matvelha[2, 0]))
                {
                    vitoria = true;
                }
            }
        }
    }
    return vitoria;
}