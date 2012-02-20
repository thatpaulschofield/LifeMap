<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AzureHost" generation="1" functional="0" release="0" Id="69af0938-4db2-465c-a5fc-372177fca984" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="AzureHostGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/AzureHost/AzureHostGroup/LB:LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapCertificate|LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:AzureProfileConfig.Profiles" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:AzureProfileConfig.Profiles" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:AzureQueueConfig.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:AzureQueueConfig.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:AzureQueueConfig.QueueName" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:AzureQueueConfig.QueueName" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:DynamicHostControllerConfig.AutoUpdate" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:DynamicHostControllerConfig.AutoUpdate" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:DynamicHostControllerConfig.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:DynamicHostControllerConfig.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:DynamicHostControllerConfig.UpdateInterval" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:DynamicHostControllerConfig.UpdateInterval" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:MessageForwardingInCaseOfFaultConfig.ErrorQueue" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:MessageForwardingInCaseOfFaultConfig.ErrorQueue" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:MsmqTransportConfig.MaxRetries" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:MsmqTransportConfig.MaxRetries" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.Host:MsmqTransportConfig.NumberOfWorkerThreads" defaultValue="">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.Host:MsmqTransportConfig.NumberOfWorkerThreads" />
          </maps>
        </aCS>
        <aCS name="LifeMap.NServiceBus.HostInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/AzureHost/AzureHostGroup/MapLifeMap.NServiceBus.HostInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:AzureProfileConfig.Profiles" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/AzureProfileConfig.Profiles" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:AzureQueueConfig.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/AzureQueueConfig.ConnectionString" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:AzureQueueConfig.QueueName" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/AzureQueueConfig.QueueName" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:DynamicHostControllerConfig.AutoUpdate" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/DynamicHostControllerConfig.AutoUpdate" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:DynamicHostControllerConfig.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/DynamicHostControllerConfig.ConnectionString" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:DynamicHostControllerConfig.UpdateInterval" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/DynamicHostControllerConfig.UpdateInterval" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:MessageForwardingInCaseOfFaultConfig.ErrorQueue" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/MessageForwardingInCaseOfFaultConfig.ErrorQueue" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:MsmqTransportConfig.MaxRetries" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/MsmqTransportConfig.MaxRetries" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.Host:MsmqTransportConfig.NumberOfWorkerThreads" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/MsmqTransportConfig.NumberOfWorkerThreads" />
          </setting>
        </map>
        <map name="MapLifeMap.NServiceBus.HostInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.HostInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="LifeMap.NServiceBus.Host" generation="1" functional="0" release="0" software="C:\projects\LifeMap\src\LifeMap.AzureHost\csx\Release\roles\LifeMap.NServiceBus.Host" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/AzureHost/AzureHostGroup/SW:LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="AzureProfileConfig.Profiles" defaultValue="" />
              <aCS name="AzureQueueConfig.ConnectionString" defaultValue="" />
              <aCS name="AzureQueueConfig.QueueName" defaultValue="" />
              <aCS name="DynamicHostControllerConfig.AutoUpdate" defaultValue="" />
              <aCS name="DynamicHostControllerConfig.ConnectionString" defaultValue="" />
              <aCS name="DynamicHostControllerConfig.UpdateInterval" defaultValue="" />
              <aCS name="MessageForwardingInCaseOfFaultConfig.ErrorQueue" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="MsmqTransportConfig.MaxRetries" defaultValue="" />
              <aCS name="MsmqTransportConfig.NumberOfWorkerThreads" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;LifeMap.NServiceBus.Host&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;LifeMap.NServiceBus.Host&quot;&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.HostInstances" />
            <sCSPolicyFaultDomainMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.HostFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="LifeMap.NServiceBus.HostFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="LifeMap.NServiceBus.HostInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="cb4f01c0-f2f6-49d1-b99e-e95af1c53ca0" ref="Microsoft.RedDog.Contract\ServiceContract\AzureHostContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="bb703362-c207-4d44-b244-99888679dceb" ref="Microsoft.RedDog.Contract\Interface\LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/AzureHost/AzureHostGroup/LifeMap.NServiceBus.Host:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>