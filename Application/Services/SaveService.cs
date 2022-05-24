﻿namespace Application.Services
{
    using Application.DTO.Request;
    using Application.DTO.Responce;
    using Application.Interfaces;
    using Domain.Repository;

    public class SaveService : ISaveService
    {
        private ISaveRepository _saveRepository;

        public SaveService(ISaveRepository saveRepository)
        {
            _saveRepository = saveRepository;
        }

        public void DeleteSave(int id)
        {
            _saveRepository.DeleteSave(id);
        }

        public SaveDto GetSaveByUsername(string username)
        {
            return new SaveDto(_saveRepository.GetSaveByUsername(username));
        }

        public SaveDto NewSave(SaveCreateRequestDto save)
        {
            return new SaveDto(_saveRepository.NewSave(save.ToModel()));
        }

        public SaveDto UpdateSave(int id, string saveFileName)
        {
            return new SaveDto(_saveRepository.UpdateSave(id, saveFileName));
        }
    }
}