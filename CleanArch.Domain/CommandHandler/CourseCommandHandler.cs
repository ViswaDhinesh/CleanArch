using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Domain.CommandHandler
{
    public class CourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        public readonly ICourseRepository _courseRepositoty;

        public CourseCommandHandler (ICourseRepository courseRepository)
        {
            _courseRepositoty = courseRepository;
        }

        public Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course()
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            };

            _courseRepositoty.Add(course);

            return Task.FromResult(true);
        }
    }
}
