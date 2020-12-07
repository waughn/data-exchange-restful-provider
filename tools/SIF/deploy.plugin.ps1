<#
.SYNOPSIS
    .
.DESCRIPTION
    .
.PARAMETER TenantServiceInstanceName
    Provide tenant service instance name.
.PARAMETER ServicePackage
    Provide full path to Tenant Service web deployment package here.
#>
param
(
 [Parameter(Mandatory=$false )] [string] $TenantServiceInstanceName,
 [Parameter(Mandatory=$false )] [string] $ServicePackage,
 [Parameter(Mandatory=$false )] [string] $WDSFolderName = $pwd
)

#deploy package to tenant service
$tenantPackageParams = @{
 Path = "$WDSFolderName\plugin-xp0.json"
 Package = "$ServicePackage"
 SiteName = $TenantServiceInstanceName
}

Install-SitecoreConfiguration @tenantPackageParams