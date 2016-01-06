using Akka.Actor;
using Akka.Cluster;
using NLog;

namespace Lighthouse
{
    public class MemberLoggingActor : ReceiveActor
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MemberLoggingActor()
        {
            Receive<ClusterEvent.MemberUp>(m => logger.Info($"Member Up: {m.Member.Address} is [{m.Member.Status}] with roles [{string.Join(",", m.Member.Roles)}]"));
            Receive<ClusterEvent.MemberRemoved>(m => logger.Info($"Member Removed: {m.Member.Address} is [{m.Member.Status}] with roles [{string.Join(",", m.Member.Roles)}]"));

            Receive<ClusterEvent.MemberStatusChange>(m => logger.Info($"{m.GetType().Name}: {m}"));
        }
    }
}