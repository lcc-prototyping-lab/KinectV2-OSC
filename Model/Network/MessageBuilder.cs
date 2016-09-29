using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Microsoft.Kinect.Face;
using Rug.Osc;

namespace KinectV2OSC.Model.Network
{
    public class MessageBuilder
    {
        public OscMessage BuildJointMessage(Body body, KeyValuePair<JointType, Joint> joint, JointOrientation orient)
        {
            var address = String.Format("/bodies/{0}/joints/{1}", body.TrackingId, joint.Key);
            var position = joint.Value.Position;
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, position.X, position.Y, position.Z,orient.Orientation.X , orient.Orientation.Y , orient.Orientation.Z, orient.Orientation.W, joint.Value.TrackingState.ToString());
        }

        public OscMessage BuildHandMessage(Body body, string key, HandState state, TrackingConfidence confidence)
        {
            var address = String.Format("/bodies/{0}/hands/{1}", body.TrackingId, key);
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, state.ToString(), confidence.ToString());
        }

        public OscMessage BuildAUMessage(ulong tackingid,string key,float au)
        {
            var address = String.Format("/faces/{0}/au/{1}", tackingid, key);
            return new OscMessage(address,au);
        }
    }
}
