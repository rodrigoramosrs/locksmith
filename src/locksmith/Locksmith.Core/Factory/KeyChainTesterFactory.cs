using Locksmith.Core.Model.Core;
using Locksmith.Core.Model.Platform;
using Locksmith.Core.Model.Request;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Locksmith.Core.Factory
{
    public static class KeyChainTesterFactory
    {
        public static KeychainTestResult TestSecret(eTestType testType, string Secret)
        {
            KeychainTestResult result = null;
            //result = TestABTasty(Secret);
            switch (testType)
            {
                case eTestType.ABTasty_API_Key:
                    result = TestABTasty_API_Key(Secret);
                    break;
                case eTestType.Algolia_API_key:
                    result = TestAlgolia_API_key(Secret);
                    break;
                case eTestType.Amplitude_API_Keys:
                    result = TestAmplitude_API_Keys(Secret);
                    break;
                case eTestType.Asana_Access_token:
                    result = TestAsana_Access_token(Secret);
                    break;
                case eTestType.AWS_Access_Key_ID_and_Secret:
                    result = TestAWS_Access_Key_ID_and_Secret(Secret);
                    break;
                case eTestType.Azure_Application_Insights_APP_ID_and_API_Key:
                    result = TestAzure_Application_Insights_APP_ID_and_API_Key(Secret);
                    break;
                case eTestType.Bing_Maps_API_Key:
                    result = TestBing_Maps_API_Key(Secret);
                    break;
                case eTestType.Bit_ly_Access_token:
                    result = TestBit_ly_Access_token(Secret);
                    break;
                case eTestType.Branch_io_Key_and_Secret:
                    result = TestBranch_io_Key_and_Secret(Secret);
                    break;
                case eTestType.BrowserStack_Access_Key:
                    result = TestBrowserStack_Access_Key(Secret);
                    break;
                case eTestType.Buildkite_Access_token:
                    result = TestBuildkite_Access_token(Secret);
                    break;
                case eTestType.ButterCMS_API_Key:
                    result = TestButterCMS_API_Key(Secret);
                    break;
                case eTestType.Calendly_API_Key:
                    result = TestCalendly_API_Key(Secret);
                    break;
                case eTestType.CircleCI_Access_Token:
                    result = TestCircleCI_Access_Token(Secret);
                    break;
                case eTestType.Cypress_record_key:
                    result = TestCypress_record_key(Secret);
                    break;
                case eTestType.DataDog_API_key:
                    result = TestDataDog_API_key(Secret);
                    break;
                case eTestType.Deviant_Art_Access_Token:
                    result = TestDeviant_Art_Access_Token(Secret);
                    break;
                case eTestType.Deviant_Art_Secret:
                    result = TestDeviant_Art_Secret(Secret);
                    break;
                case eTestType.Dropbox_API:
                    result = TestDropbox_API(Secret);
                    break;
                case eTestType.Facebook_Access_Token:
                    result = TestFacebook_Access_Token(Secret);
                    break;
                case eTestType.Facebook_AppSecret:
                    result = TestFacebook_AppSecret(Secret);
                    break;
                case eTestType.Firebase:
                    result = TestFirebase(Secret);
                    break;
                case eTestType.Firebase_Cloud_Messaging_FCM:
                    result = TestFirebase_Cloud_Messaging_(Secret);
                    break;
                case eTestType.FreshDesk_API_Key:
                    result = TestFreshDesk_API_Key(Secret);
                    break;
                case eTestType.Github_client_id_and_client_secret:
                    result = TestGithub_client_id_and_client_secret(Secret);
                    break;
                case eTestType.GitHub_private_SSH_key:
                    result = TestGitHub_private_SSH_key(Secret);
                    break;
                case eTestType.Github_Token:
                    result = TestGithub_Token(Secret);
                    break;
                case eTestType.Gitlab_personal_access_token:
                    result = TestGitlab_personal_access_token(Secret);
                    break;
                case eTestType.Google_Cloud_Service_Account_credentials:
                    result = TestGoogle_Cloud_Service_Account_credentials(Secret);
                    break;
                case eTestType.Google_Maps_API_key:
                    result = TestGoogle_Maps_API_key(Secret);
                    break;
                case eTestType.Google_Recaptcha_key:
                    result = TestGoogle_Recaptcha_key(Secret);
                    break;
                case eTestType.Heroku_API_key:
                    result = TestHeroku_API_key(Secret);
                    break;
                case eTestType.HubSpot_API_key:
                    result = TestHubSpot_API_key(Secret);
                    break;
                case eTestType.Instagram_Access_Token:
                    result = TestInstagram_Access_Token(Secret);
                    break;
                case eTestType.Instagram_Basic_Display_API:
                    result = TestInstagram_Basic_Display_API(Secret);
                    break;
                case eTestType.Instagram_Graph_API:
                    result = TestInstagram_Graph_API(Secret);
                    break;
                case eTestType.Ipstack_API_Key:
                    result = TestIpstack_API_Key(Secret);
                    break;
                case eTestType.Iterable_API_Key:
                    result = TestIterable_API_Key(Secret);
                    break;
                case eTestType.JumpCloud_API_Key:
                    result = TestJumpCloud_API_Key(Secret);
                    break;
                case eTestType.Keen_io_API_Key:
                    result = TestKeen_io_API_Key(Secret);
                    break;
                case eTestType.Lokalise_API_Key:
                    result = TestLokalise_API_Key(Secret);
                    break;
                case eTestType.Loqate_API_Key:
                    result = TestLoqate_API_Key(Secret);
                    break;
                case eTestType.MailChimp_API_Key:
                    result = TestMailChimp_API_Key(Secret);
                    break;
                case eTestType.MailGun_Private_Key:
                    result = TestMailGun_Private_Key(Secret);
                    break;
                case eTestType.Mapbox_API_key:
                    result = TestMapbox_API_key(Secret);
                    break;
                case eTestType.Microsoft_Azure_Tenant:
                    result = TestMicrosoft_Azure_Tenant(Secret);
                    break;
                case eTestType.Microsoft_Shared_Access_Signatures_SAS:
                    result = TestMicrosoft_Shared_Access_Signatures_(Secret);
                    break;
                case eTestType.New_Relic_Personal_API_Key_NerdGraph:
                    result = TestNew_Relic_Personal_API_Key_(Secret);
                    break;
                case eTestType.New_Relic_REST_API:
                    result = TestNew_Relic_REST_API(Secret);
                    break;
                case eTestType.NPM_token:
                    result = TestNPM_token(Secret);
                    break;
                case eTestType.Pagerduty_API_token:
                    result = TestPagerduty_API_token(Secret);
                    break;
                case eTestType.Paypal_client_id_and_secret_key:
                    result = TestPaypal_client_id_and_secret_key(Secret);
                    break;
                case eTestType.Pendo_Integration_Key:
                    result = TestPendo_Integration_Key(Secret);
                    break;
                case eTestType.PivotalTracker_API_Token:
                    result = TestPivotalTracker_API_Token(Secret);
                    break;
                case eTestType.Razorpay_API_key_and_secret_key:
                    result = TestRazorpay_API_key_and_secret_key(Secret);
                    break;
                case eTestType.Salesforce_API_key:
                    result = TestSalesforce_API_key(Secret);
                    break;
                case eTestType.SauceLabs_Username_and_access_Key:
                    result = TestSauceLabs_Username_and_access_Key(Secret);
                    break;
                case eTestType.SendGrid_API_Token:
                    result = TestSendGrid_API_Token(Secret);
                    break;
                case eTestType.Slack_API_token:
                    result = TestSlack_API_token(Secret);
                    break;
                case eTestType.Slack_Webhook:
                    result = TestSlack_Webhook(Secret);
                    break;
                case eTestType.Sonarcloud:
                    result = TestSonarcloud(Secret);
                    break;
                case eTestType.Spotify_Access_Token:
                    result = TestSpotify_Access_Token(Secret);
                    break;
                case eTestType.Square:
                    result = TestSquare(Secret);
                    break;
                case eTestType.Stripe_Live_Token:
                    result = TestStripe_Live_Token(Secret);
                    break;
                case eTestType.Travis_CI_API_token:
                    result = TestTravis_CI_API_token(Secret);
                    break;
                case eTestType.Twilio_Account_sid_and_Auth_token:
                    result = TestTwilio_Account_sid_and_Auth_token(Secret);
                    break;
                case eTestType.Twitter_API_Secret:
                    result = TestTwitter_API_Secret(Secret);
                    break;
                case eTestType.Twitter_Bearer_token:
                    result = TestTwitter_Bearer_token(Secret);
                    break;
                case eTestType.Visual_Studio_App_Center_API_Token:
                    result = TestVisual_Studio_App_Center_API_Token(Secret);
                    break;
                case eTestType.WakaTime_API_Key:
                    result = TestWakaTime_API_Key(Secret);
                    break;
                case eTestType.WeGlot_Api_Key:
                    result = TestWeGlot_Api_Key(Secret);
                    break;
                case eTestType.WPEngine_API_Key:
                    result = TestWPEngine_API_Key(Secret);
                    break;
                case eTestType.YouTube_API_Key:
                    result = TestYouTube_API_Key(Secret);
                    break;
                case eTestType.Zapier_Webhook_Token:
                    result = TestZapier_Webhook_Token(Secret);
                    break;
                case eTestType.Zendesk_Access_token:
                    result = TestZendesk_Access_token(Secret);
                    break;
                default:
                    break;
            }

            return result;// RequestFactory.ExecuteRequest(requestObj).GetAwaiter().GetResult();
        }

        private static KeychainTestResult TestABTasty_API_Key(string secret)
        {
            //https://developers.abtasty.com/server-side.html#authentication
            //curl "api_endpoint_here" -H "x-api-key: your_api_key"
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestAlgolia_API_key(string secret)
        {
            //https://www.algolia.com/doc/rest-api/search/#overview
            //Be cautious when running this command, since the payload might execute within an administrative environment, depending on what index you are editing the highlightPreTag of. It's recommended to use a more silent payload (such as XSS Hunter) to prove the possible cross-site scripting attack.

            RequestFactory.ExecuteCurlRequest("--request PUT --url https://<application-id>-1.algolianet.com/1/indexes/<example-index>/settings --header 'content-type: application/json'  --header 'x-algolia-api-key: <example-key>' --header 'x-algolia-application-id: <example-application-id>'  --data '{\"highlightPreTag\": \"<script>alert(1);</script>\"}'");
            /*
             curl --request PUT \
              --url https://<application-id>-1.algolianet.com/1/indexes/<example-index>/settings \
              --header 'content-type: application/json' \
              --header 'x-algolia-api-key: <example-key>' \
              --header 'x-algolia-application-id: <example-application-id>' \
              --data '{"highlightPreTag": "<script>alert(1);</script>"}'
             */

            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestAmplitude_API_Keys(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestAsana_Access_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestAWS_Access_Key_ID_and_Secret(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestAzure_Application_Insights_APP_ID_and_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestBing_Maps_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestBit_ly_Access_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestBranch_io_Key_and_Secret(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestBrowserStack_Access_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestBuildkite_Access_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestButterCMS_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestCalendly_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestCircleCI_Access_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestCypress_record_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestDataDog_API_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestDeviant_Art_Access_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestDeviant_Art_Secret(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestDropbox_API(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestFacebook_Access_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestFacebook_AppSecret(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestFirebase(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestFirebase_Cloud_Messaging_(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestFreshDesk_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestGithub_client_id_and_client_secret(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestGitHub_private_SSH_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestGithub_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestGitlab_personal_access_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestGoogle_Cloud_Service_Account_credentials(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestGoogle_Maps_API_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestGoogle_Recaptcha_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestHeroku_API_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestHubSpot_API_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestInstagram_Access_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestInstagram_Basic_Display_API(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestInstagram_Graph_API(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestIpstack_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestIterable_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestJumpCloud_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestKeen_io_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestLokalise_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestLoqate_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestMailChimp_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestMailGun_Private_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestMapbox_API_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestMicrosoft_Azure_Tenant(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestMicrosoft_Shared_Access_Signatures_(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestNew_Relic_Personal_API_Key_(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }


        private static KeychainTestResult TestNew_Relic_REST_API(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestNPM_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestPagerduty_API_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestPaypal_client_id_and_secret_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestPendo_Integration_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestPivotalTracker_API_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestRazorpay_API_key_and_secret_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSalesforce_API_key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSauceLabs_Username_and_access_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSendGrid_API_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSlack_API_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSlack_Webhook(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSonarcloud(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSpotify_Access_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestSquare(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestStripe_Live_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestTravis_CI_API_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestTwilio_Account_sid_and_Auth_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestTwitter_API_Secret(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestTwitter_Bearer_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestVisual_Studio_App_Center_API_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestWakaTime_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestWeGlot_Api_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestWPEngine_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestYouTube_API_Key(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestZapier_Webhook_Token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

        private static KeychainTestResult TestZendesk_Access_token(string secret)
        {
            throw new NotImplementedException();
            RequestModel requestModel = new RequestModel();
            var result = RequestFactory.ExecuteRequest(requestModel).GetAwaiter().GetResult();
            return new KeychainTestResult();
        }

    }
}
