char[,] matvelha = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
char[,] maux = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
char esc = ' ';
bool game = true, vitoria = false;
int jogador = 0, rodada = 0;
string j1, j2;

Console.WriteLine("jogo da velha");
Console.WriteLine("\nObejtivo: Completar com x ou o uma lina, coluna ou diagonal do tabuleiro.\n" +
    "Ganha o jogador que o preencher primeiro. \nA peça x é quem começa. As jogadas são intercalada " +
    "entre x e o. \n\nPrecione qualquer tecla para prosseguir");
Console.ReadLine();


Jogo();

void Jogo()
{
    XorO();
    ImprimirMatriz(maux);
    while (game)
    {
        if (!Velha())
        {
            break;
        }
        VerificarJogador();
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
    }
    Jogar();
}
//Impressão da matriz
char[,] ImprimirMatriz(char[,] matv)
{
    Console.Clear();
    Console.WriteLine("Jogo da velha.");
    for (int l = 0; l < matv.GetLength(0); l++)
    {
        for (int c = 0; c < matv.GetLength(1); c++)
        {
            Console.Write("|" + matv[l, c] + "|");
        }
        Console.WriteLine();
    }
    return matv;
}
//Verificando se o digito é o solicitado
bool VerificarDigito(char esc)
{
    bool verifica = false;
    for (int l = 0; l < maux.GetLength(0); l++)
    {
        for (int c = 0; c < maux.GetLength(1); c++)
        {
            if (esc.Equals(maux[l, c]))
            {
                verifica = true;
            }
        }
    }
    return verifica;
}
//Verificando se o espaço solicitado esta disponivel
bool VerificarLugar(char esc)
{
    bool disponivel = false;

    for (int l = 0; l < maux.GetLength(0); l++)
    {
        for (int c = 0; c < maux.GetLength(1); c++)
        {
            if (esc == maux[l, c])
            {
                disponivel = true;
                AtribuirEscolha();
                break;
            }
        }
    }
    return disponivel;
}
//Atribui o "Valor" desejado na matriz
void AtribuirEscolha()
{
    for (int l = 0; l < maux.GetLength(0); l++)
    {
        for (int c = 0; c < maux.GetLength(1); c++)
        {
            if (esc.Equals(maux[l, c]))
            {
                if (jogador % 2 == 0)
                {
                    maux[l, c] = 'X';
                    ImprimirMatriz(maux);
                    if (CondicaoVitoria())
                    {
                        Console.WriteLine("O jogo acabou! Vencedor " + j1);
                        game = false;
                        Console.ReadLine();
                    }
                }
                else if (jogador % 2 == 1)
                {
                    maux[l, c] = 'O';
                    ImprimirMatriz(maux);
                    if (CondicaoVitoria())
                    {
                        Console.WriteLine("O jogo acabou! Vencedor " + j2);
                        game = false;
                        Console.ReadLine();
                    }
                }
                jogador += 1;
            }
        }
    }
}
//Verifica se as condições para vitória foram satisfeitas
bool CondicaoVitoria()
{

    for (int l = 0; l < maux.GetLength(0); l++)
    {
        for (int c = 0; c < maux.GetLength(1); c++)
        {
            //Se as linhs forem iguais
            if ((maux[l, 0] == maux[l, 1]) && (maux[l, 1] == maux[l, 2]))
            {
                vitoria = true;
            }
            //Colunas iguais
            else if ((maux[0, c] == maux[1, c]) && (maux[1, c] == maux[2, c]))
            {
                vitoria = true;
            }
            //Diagonal principal
            else if ((maux[0, 0] == maux[1, 1]) && (maux[1, 1] == maux[2, 2]))
            {
                vitoria = true;
            }
            //Diagonal secundária
            else if ((maux[0, 2] == maux[1, 1]) && (maux[1, 1] == maux[2, 0]))
            {
                vitoria = true;
            }
        }
    }

    return vitoria;
}
void XorO()
{
    Console.Clear();
    Console.WriteLine("NOME DOS JOGADORES.");
    Console.Write("Nome do jogador X: ");
    j1 = Console.ReadLine();
    Console.Write("Nome do jogador O: ");
    j2 = Console.ReadLine();
}
bool VerificarJogador()
{
    if (jogador % 2 == 0 && game)
    {
        Console.Write("Escolha uma posição {0}(X): ", j1);
        esc = char.Parse(Console.ReadLine());
        return true;
    }
    else
    {
        Console.Write("Escolha uma posição {0}(O): ", j2);
        esc = char.Parse(Console.ReadLine());
        return false;
    }
}
bool Velha()
{
    if (rodada == 9 && vitoria == false)
    {
        ImprimirMatriz(maux);
        Console.WriteLine("Velha!!!");
        game = false;
    }
    return game;
}
void Jogar()
{
    Console.WriteLine("Deseja jogar novamente (S/N)");
    char tecla = char.Parse(Console.ReadLine().ToUpper());
    if (tecla == 'S')
    {
        maux = matvelha;
        jogador = 0;
        rodada = 0;
        vitoria = false;
        game = true;
        Jogo();
    }
}