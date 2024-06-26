﻿using System;
using System.Collections.Generic;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
using SzpitalAPP.Repository;

namespace SzpitalAPP.Components.DataProviders
{
    public class DoctorProvider : IDoctorProvider
    {
        private readonly IRepository<Doctor> _doctorRepository;
        public DoctorProvider(IRepository<Doctor> repository)
        {
            _doctorRepository = repository;
        }
        public List<Doctor> GetDoctorsByAge()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.OrderBy(x => x.Age).ToList();
        }

        public List<Doctor> GetDoctorsByBranch()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.OrderBy(x => x.Branch).ToList();
        }

        public List<Doctor> GetDoctorsByCountry()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.OrderBy(x => x.Country).ToList();
        }

        public List<Doctor> GetDoctorsByName()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.OrderBy(x => x.Name).ThenBy(x => x.SurName).ToList();
        }

        public List<Doctor> GetDoctorsBySalary()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.OrderBy(x => x.Salary).ToList();
        }

        public decimal GetMaxDoctorSalary()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.Select(x => x.Salary).Max();
        }
        public List<Branch> GetUniqueBranch()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.Select(x => x.Branch).Distinct().ToList();
        }

        public List<string> GetUniqueCity()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.Select(x => x.City).Distinct().ToList();
        }

        public List<string> GetUniqueNationality()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors.Select(x => x.Country).Distinct().ToList();
        }
    }
}
