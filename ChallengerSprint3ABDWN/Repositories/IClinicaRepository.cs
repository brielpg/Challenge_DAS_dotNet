﻿using ABDWNSprint1.Models;

namespace ABDWNSprint1.Repositories
{
    public interface IClinicaRepository
    {
        IEnumerable<Clinica> ListarClinicas();
        Clinica BuscarClinicaPorId(int id);
        void Inserir(Clinica clinica);
        void Atualizar(Clinica clinica);
        void Deletar(int id);
        Clinica Login(string email, string senha);
    }
}
