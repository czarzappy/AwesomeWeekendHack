/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace strange.examples.signals
{
	//Not extending EventMediator anymore
	public class SpaceShipMediator : Mediator
	{
		[Inject]
		public AwesomeSpaceShipView view{ get; set;}
		
		//Injecting this one because we want to listen for it
		[Inject]
		public ColorChangedSignal colorChangedSignal{ get; set;}
		
		//Injecting this one because we want to fire it
		//[Inject]
		//public CallWebServiceSignal callWebServiceSignal{ get; set;}
		
		public override void OnRegister()
		{
			//Listen out for this Signal to fire
			colorChangedSignal.AddListener(onColorChange);
			
			//Listen to the view for a Signal
			//view.clickSignal.AddListener(onViewClicked);
			
			view.init ();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners just as you do with EventDispatcher
			colorChangedSignal.RemoveListener(onColorChange);
			//view.clickSignal.RemoveListener(onViewClicked);
			Debug.Log("Mediator OnRemove");
		}
		
//		private void onViewClicked()
//		{
//			Debug.Log("View click detected");
//			//Dispatch a Signal. We're adding a string value (different from MyFirstContext,
//			//just to show how we can Inject values into commands)
//			//callWebServiceSignal.Dispatch(view.currentText);
//		}
		
		//Note how the callback is strongly typed
//		private void onScoreChange(string score)
//		{
//			//view.updateScore(score);
//		}

		private void onColorChange(Color shipColor)
		{
			view.UpdateColor (shipColor);
		}
	}
}

