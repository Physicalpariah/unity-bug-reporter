//Created by Matt Purchase.
//  Copyright (c) 2022 Matt Purchase. All rights reserved.
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;


public class BugReporterControllerTests {
	// Properties

	// Tests
	[SetUp]
	public void Setup() {
		BugReporterController ctrl = BugReporterController.Instance;
	}

	[TearDown]
	public void TearDown() {

	}

	[Test]
	public void InstanceExists() {
		if (BugReporterController.Instance == null) {
			Assert.Fail();
		}

		Assert.Pass();
	}

	[Test]
	public void CreatesValidJson() {
		string json = BugReporterController.Instance.BuildJSON("report", "playerData", "gameData");

		try {
			Root obj = UnityEngine.JsonUtility.FromJson<Root>(json);
		}
		catch {
			Assert.Fail();
		}

		Assert.Pass();
	}

	[UnityTest]
	public IEnumerator SendsReport() {
		yield return BugReporterController.Instance.DoreportSend("bug report test", "test data", "game data");

		if (BugReporterController.Instance.m_lastRequest.result != UnityEngine.Networking.UnityWebRequest.Result.Success) {
			Assert.Fail();
		}

		Assert.Pass();
	}
}

