namespace SoftJail.DataProcessor
{

    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Newtonsoft.Json;

    using Data;
    using ImportDto;
    using Data.Models;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentWithCellsDto[] departmentDtos =
                JsonConvert.DeserializeObject<ImportDepartmentWithCellsDto[]>(jsonString);

            ICollection<Department> departments = new HashSet<Department>();

            foreach (var departmentlDto in departmentDtos)
            {
                if (!IsValid(departmentlDto))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                if (!departmentlDto.Cells.Any())
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                if (departmentlDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentlDto.Name
                };

                foreach (var depCellDto in departmentlDto.Cells)
                {
                    Cell cell = Mapper.Map<Cell>(depCellDto);
                    department.Cells.Add(cell);
                }

                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}