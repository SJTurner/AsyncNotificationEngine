using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using DB;

namespace QueryProviders
{
    public class I9RuleQueryProvider : IRuleQueryProvider
    {

        public IEnumerable<CompanyRuleConfiguaration> GetCompanyRuleConfiguarations()
        {
            return Database.I9RuleCompanyConfigs;
        }

        public IEnumerable<Employee> GetNotificationRecipients(CompanyRuleConfiguaration config)
        {
            return Database.Employees.Where(x => x.CompanyId == config.CompanyId && x.I9Expires == DateTime.Today.AddDays(config.DaysBeforeEventToSendNotification)); 
        }
    }
}
