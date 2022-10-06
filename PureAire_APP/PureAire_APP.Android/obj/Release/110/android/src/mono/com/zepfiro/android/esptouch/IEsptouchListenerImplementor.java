package mono.com.zepfiro.android.esptouch;


public class IEsptouchListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.zepfiro.android.esptouch.IEsptouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onEsptouchResultAdded:(Lcom/zepfiro/android/esptouch/IEsptouchResult;)V:GetOnEsptouchResultAdded_Lcom_zepfiro_android_esptouch_IEsptouchResult_Handler:Com.Zepfiro.Android.Esptouch.IEsptouchListenerInvoker, EspTouchBinding_Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Zepfiro.Android.Esptouch.IEsptouchListenerImplementor, EspTouchBinding_Droid", IEsptouchListenerImplementor.class, __md_methods);
	}


	public IEsptouchListenerImplementor ()
	{
		super ();
		if (getClass () == IEsptouchListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Zepfiro.Android.Esptouch.IEsptouchListenerImplementor, EspTouchBinding_Droid", "", this, new java.lang.Object[] {  });
	}


	public void onEsptouchResultAdded (com.zepfiro.android.esptouch.IEsptouchResult p0)
	{
		n_onEsptouchResultAdded (p0);
	}

	private native void n_onEsptouchResultAdded (com.zepfiro.android.esptouch.IEsptouchResult p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
