using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using DB;

namespace QueryProviders
{
    public class BirthdayRuleQueryProvider : IRuleQueryProvider
    {

        public IEnumerable<CompanyRuleConfiguaration> GetCompanyRuleConfiguarations()
        {
            return Database.BirthdayRuleCompanyConfigs;
        }

        public IEnumerable<Employee> GetNotificationRecipients(CompanyRuleConfiguaration config)
        {
            return Database.Employees.Where(x => x.CompanyId == config.CompanyId && x.BirthDay == DateTime.Today.AddDays(config.DaysBeforeEventToSendNotification)); 
        }

    }
}
