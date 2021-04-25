using SumulaFacil.dao;


namespace SumulaFacil.Icontroladores
{
  public interface IusuarioControlador
    {
        bool loginControlador(string text1,
                              string text2,
                              int selectedIndex);
        Usuario controladorNovoDirigente(string nome, string cpf, string idade, string telefone, string cep,
            string numeroResidencial, string nomeUsuario, string senha, string confirmaSenha);
        
    }
}
