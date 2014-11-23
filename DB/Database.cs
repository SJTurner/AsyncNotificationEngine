using System;
using System.Collections.Generic;
using Dto;

namespace DB
{
    public static class Database
    {
        public static readonly List<CompanyRuleConfiguaration> BirthdayRuleCompanyConfigs = new List<CompanyRuleConfiguaration>()
        {
            new CompanyRuleConfiguaration()
            {
                CompanyId = 1,
                DaysBeforeEventToSendNotification = 0,
                NotificationType = NotificationType.All
            },
            new CompanyRuleConfiguaration()
            {
                CompanyId = 2,
                DaysBeforeEventToSendNotification = 0,
                NotificationType =  NotificationType.Dashboard
            },
            new CompanyRuleConfiguaration()
            {
                CompanyId = 3,
                DaysBeforeEventToSendNotification = 0,
                NotificationType =  NotificationType.Sms
            }
        };

        public static readonly List<CompanyRuleConfiguaration> I9RuleCompanyConfigs = new List<CompanyRuleConfiguaration>()
        {
            new CompanyRuleConfiguaration()
            {
                CompanyId = 1,
                DaysBeforeEventToSendNotification = 10,
                NotificationType = NotificationType.Email
            },
            new CompanyRuleConfiguaration()
            {
                CompanyId = 3,
                DaysBeforeEventToSendNotification = 10,
                NotificationType = NotificationType.All
            },
            new CompanyRuleConfiguaration()
            {
                CompanyId = 2,
                DaysBeforeEventToSendNotification = 5,
                NotificationType = NotificationType.All
            }
        };

        public static readonly List<Employee> Employees = new List<Employee>()
        {
            new Employee()
            {
                EmployeeId = 1,
                CompanyId = 1,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 2,
                CompanyId = 1,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 3,
                CompanyId = 1,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 4,
                CompanyId = 1,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 5,
                CompanyId = 2,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 6,
                CompanyId = 2,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 7,
                CompanyId = 2,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 8,
                CompanyId = 3,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 9,
                CompanyId = 3,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 10,
                CompanyId = 3,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 11,
                CompanyId = 3,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 12,
                CompanyId = 3,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(10)
            },
            new Employee()
            {
                EmployeeId = 13,
                CompanyId = 2,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(5)
            },
            new Employee()
            {
                EmployeeId = 14,
                CompanyId = 2,
                BirthDay = DateTime.Today,
                I9Expires = DateTime.Today.AddDays(5)
            }

        };
    }
}
