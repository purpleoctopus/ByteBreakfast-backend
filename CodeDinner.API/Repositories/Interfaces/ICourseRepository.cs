﻿using CodeDinner.API.Entities;
using CodeDinner.API.Models;

namespace CodeDinner.API.Repositories.Interfaces;

public interface ICourseRepository
{
    Task<Course?> AddAsync(Course course);
    Task<List<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<Course?> UpdateAsync(Course model);
}