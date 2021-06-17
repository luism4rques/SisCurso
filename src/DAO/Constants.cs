namespace DAO
{
    public static class Constants
    {
        public static class Operacao
        {
            public static int CRIAR = 1;
            public static int CONSULTAR = 2;
            public static int ATUALIZAR = 3;
            public static int EXCLUIR = 4;
        }

        public static class Funcionalidade
        {
            public static int PERMISSAO = 1;
            public static int CONTATO = 2;
            public static int TELEFONE = 3;
        }

        public static class Permissao
        {
            public static string VALOR_S = "s";
            public static string VALOR_N = "n";
        }
    }
}