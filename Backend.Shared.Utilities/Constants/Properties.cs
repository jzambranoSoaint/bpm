namespace Backend.Shared.Utilities.Constants
{
    public class Properties
    {
        public const string Protocol = "http://";
        public const string IpServer = "sdspam-kieserver-des-sds-infra-transversal.apps.openshiftdev.soain.lcl";
        public const string PortServer = "";
        public const string ContainerProcessJbpm = "Prueba_1.0.0-SNAPSHOT";
        public const string EndpointApiJbpmBase = "/services/rest";

        public const string EndpointMain = Protocol + IpServer + PortServer + EndpointApiJbpmBase;

        public const string EndpointApiJbpmProcessStartProcessInstance = EndpointMain + "/server/containers/";
        public const string EndpointApiJbpmProcessVariables = EndpointMain + "/server/containers/";
        public const string EndpointApiJbpmTaskPotOwner = EndpointMain + "/server/queries/tasks/instances/pot-owners";
        public const string EndpointApiJbpmProcessModifyStatus = EndpointMain + "/server/containers/";
        public const string EndpoitnApiJbpmProcessModifyVariables = EndpointMain + "/server/containers/";
        public const string EndpointApiJbpmProcessQueries = EndpointMain + "/server/queries/variables/processes/tasks";
        public const string EndpointApiJbpmProcessSignal = EndpointMain + "/server/containers/";
    }
}
