using SumulaFacil.dao;
using System;


namespace SumulaFacil.idao
{
    public interface IdaoUsuario
    {
        Boolean login(Usuario u);
        Boolean inserirUsuarioDirigente(Usuario u);
        Boolean apagar(Usuario u);
        Boolean consultaNomeCadastrado(string nome);
        Boolean consultaCpfCadastrado(string cpf);
        Boolean consultaNomeUsuarioCadastrado(string nomeUsuario);
        Usuario carregaUsuarioNaTabela(string nomeUsuario);
        Boolean consultaSenhaCadastrada(string senha);
        int consultaIdPorNome(string nome);
       
    }
}
