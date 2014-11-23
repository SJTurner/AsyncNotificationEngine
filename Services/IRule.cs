using System.Collections.Generic;
using Dto;

namespace Rules
{
    public interface IRule
    {
        IEnumerable<CompanyRuleConfiguaration> GetCompanyRuleConfiguarations();
        void Execute(CompanyRuleConfiguaration config);
    }
}
