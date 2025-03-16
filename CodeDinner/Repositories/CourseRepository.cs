﻿using System.Net;
using CodeDinner.Data;
using CodeDinner.Exceptions;
using CodeDinner.Models.Domain;
using CodeDinner.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeDinner.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext context;

    public CourseRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(Course course)
    {
        await context.AddAsync(course);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var model = await context.Courses.FindAsync(id) ?? 
                    throw new StatusCodeException(HttpStatusCode.NotFound, "Курс не знайдено");
        context.Courses.Remove(model);
        await context.SaveChangesAsync();
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await context.Courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await context.Courses.FirstOrDefaultAsync(course => course.Id == id);
    }

    public Task UpdateAsync(Course course)
    {
        throw new NotImplementedException();
    }
}