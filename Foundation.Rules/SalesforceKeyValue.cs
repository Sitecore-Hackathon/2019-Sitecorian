using System;
using System.Globalization;
using System.Web;
using Newtonsoft.Json.Linq;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Sitecorian.Foundation.Rules
{
    public class SalesforceKeyValue<T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string CookieName { get; set; }
        public string ParamName { get; set; }
        public string ParamValue { get; set; }

        protected override bool Execute(T ruleContext)
        {
            var foundExactMatch = false;
            var foundCaseInsensitiveMatch = false;
            var foundContains = false;
            var foundStartsWith = false;
            var foundEndsWith = false;
            string myparamName = this.ParamName ?? string.Empty;
            string myparamValue = this.ParamValue ?? string.Empty;

            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie == null || string.IsNullOrEmpty(myparamName) || string.IsNullOrEmpty(myparamValue))
            {
                return false;
            }
            else
            {
                try
                {
                    string unescaped = HttpUtility.UrlDecode(cookie.Value, System.Text.Encoding.Default);
                    JObject salesforceObject = JObject.Parse(unescaped);
                    salesforceObject.TryGetValue(ParamName, StringComparison.InvariantCultureIgnoreCase, out JToken valueToken);
                    string cookieParamValue = valueToken.Value<string>() ?? string.Empty?.ToLowerInvariant();
                    if (string.Equals(cookieParamValue, myparamValue, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foundCaseInsensitiveMatch = true;
                    }
                    if (string.Equals(cookieParamValue, myparamValue))
                    {
                        foundExactMatch = true;
                        foundContains = true;
                        foundStartsWith = true;
                        foundEndsWith = true;
                    }
                    else if (cookieParamValue.Contains(myparamValue))
                    {
                        foundContains = true;
                        if (cookieParamValue.StartsWith(myparamValue, true, CultureInfo.InvariantCulture))
                        {
                            foundStartsWith = true;
                        }

                        if (cookieParamValue.EndsWith(myparamValue, true, CultureInfo.InvariantCulture))
                        {
                            foundEndsWith = true;
                        }
                    }

                    bool returnValue;
                    switch (this.GetOperator())
                    {
                        case StringConditionOperator.Equals:
                            returnValue = foundExactMatch;
                            break;
                        case StringConditionOperator.NotEqual:
                            returnValue = !foundExactMatch;
                            break;
                        case StringConditionOperator.CaseInsensitivelyEquals:
                            returnValue = foundCaseInsensitiveMatch;
                            break;
                        case StringConditionOperator.NotCaseInsensitivelyEquals:
                            returnValue = !foundCaseInsensitiveMatch;
                            break;
                        case StringConditionOperator.Contains:
                            returnValue = foundContains;
                            break;
                        case StringConditionOperator.StartsWith:
                            returnValue = foundStartsWith;
                            break;
                        case StringConditionOperator.EndsWith:
                            returnValue = foundEndsWith;
                            break;
                        default:
                            returnValue = false;
                            break;
                    }

                    return returnValue;
                }
                catch (Exception ex)
                {
                    Log.Error("Salesforce Rule Error in reading values", ex, typeof(SalesforceKeyValue<T>));
                }
            }
            return false;
        }
    }
}