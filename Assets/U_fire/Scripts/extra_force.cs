using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class extra_force : MonoBehaviour {
	private float[] PS_parameters = new float[3];
	SerializedObject so; 
	public float force_k;
	Vector3 old_pos;
	Vector3 old_vel;
	// Use this for initialization
	void Start () {
		old_pos = this.transform.position;
		so = new SerializedObject(this.GetComponent<ParticleSystem>());
		PS_parameters[0] = so.FindProperty("ForceModule.x.scalar").floatValue;
		PS_parameters[1] = so.FindProperty("ForceModule.y.scalar").floatValue;
		PS_parameters[2] = so.FindProperty("ForceModule.z.scalar").floatValue;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Apply_forces();

	}
	Vector3 Get_Velocity(){
		Vector3 velocity = (this.transform.position - old_pos)/(Time.fixedDeltaTime*3f);
		old_pos = this.transform.position;
		return velocity;
	}
	Vector3 Get_Accel(){
		Vector3 velocity = Get_Velocity();
		Vector3 acceleration = (velocity- old_vel)/(Time.fixedDeltaTime*3f);
		old_vel = velocity;
		return acceleration;
	}
	void Apply_forces(){
		Vector3 force = -Get_Accel()*force_k;
		if (force.magnitude > 5f*force_k)
			force = force/(force.magnitude/(5f*force_k));
		so.FindProperty("ForceModule.x.scalar").floatValue = PS_parameters[0] + force.x;
		so.FindProperty("ForceModule.y.scalar").floatValue = PS_parameters[1] + force.y;
		so.FindProperty("ForceModule.z.scalar").floatValue = PS_parameters[2] + force.z;
		so.ApplyModifiedProperties();
	}

}
