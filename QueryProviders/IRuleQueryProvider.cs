using System.Collections.Generic;
using Dto;

namespace QueryProviders
{
    public interface IRuleQueryProvider
    {
        IEnumerable<CompanyRuleConfiguaration> GetCompanyRuleConfiguarations();
        IEnumerable<Employee> GetNotificationRecipients(CompanyRuleConfiguaration config);
    }
}
