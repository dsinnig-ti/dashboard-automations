
global using DashboardAutomation.Common;
global using DashboardAutomation.Shared;

global using DashboardAutomation.Business;
global using DashboardAutomation.Business.Domain.Models;
global using DashboardAutomation.Business.Domain.Enums;

global using System.Diagnostics;

using System.Reflection;

namespace DashboardAutomation.Business;

public static class AssemblyInfo
{
  public static Assembly Assembly => typeof(AssemblyInfo).Assembly;
}
