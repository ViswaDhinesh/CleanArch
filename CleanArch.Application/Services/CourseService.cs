using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _autoMapper;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus, IMapper autoMapper)
        {
            _courseRepository = courseRepository;
            _bus = bus;
            _autoMapper = autoMapper;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            // Manual Mapping for values to the property using bus command

            //var createCourseCommand = new CreateCourseCommand(
            //    courseViewModel.Name,
            //    courseViewModel.Description,
            //    courseViewModel.ImageUrl
            //    );

            //_bus.SendCommand(createCourseCommand);

            // Auto Mapping for values to the property using bus command

            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        //public CourseViewModel GetCourses()
        //{
        //    return new CourseViewModel()
        //    {
        //        Courses = _courseRepository.GetCourses()
        //    };
        //}


        public IEnumerable<CourseViewModel> GetCourses()
        {
            //return new CourseViewModel()
            //{
            //    Courses = _courseRepository.GetCourses()
            //};

            return _courseRepository.GetCourses().ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
