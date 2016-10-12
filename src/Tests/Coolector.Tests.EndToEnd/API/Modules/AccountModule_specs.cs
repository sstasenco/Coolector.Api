﻿using System;
using System.Net.Http;
using Coolector.Dto.Users;
using Coolector.Tests.EndToEnd.Framework;
using Machine.Specifications;

namespace Coolector.Tests.EndToEnd.API.Modules
{
    public abstract class AccountModule_specs : ModuleBase_specs
    {
        protected static HttpResponseMessage SignIn() =>
            HttpClient.PostAsync("sign-in", new
            {
                AccessToken = Auth0SignInResponse.AccessToken
            }).WaitForResult();

        protected static UserDto GetAccount()
            => HttpClient.GetAsync<UserDto>("account").WaitForResult();
    }

    [Subject("Auth0 sign in")]
    public class when_signing_in_to_auth0 : AccountModule_specs
    {
        Establish context = () => Initialize();

        Because of = () => SignInToAuth0();

        It should_return_successful_auth0_sign_in_response = () =>
        {
            Auth0SignInResponse.ShouldNotBeNull();
            Auth0SignInResponse.AccessToken.ShouldNotBeEmpty();
            Auth0SignInResponse.IdToken.ShouldNotBeEmpty();
            Auth0SignInResponse.TokenType.ShouldNotBeEmpty();
        };
    }

    [Subject("Account sign in")]
    public class when_signing_in_to_api : AccountModule_specs
    {
        static HttpResponseMessage Response;

        Establish context = () => Initialize(authenticate: true);

        Because of = () => Response = SignIn();

        It should_return_successful_response = () => Response.IsSuccessStatusCode.ShouldBeTrue();
    }

    [Subject("Account fetch")]
    public class when_fetching_account : AccountModule_specs
    {
        static UserDto User;

        Establish context = () => Initialize(authenticate: true);

        Because of = () => User = GetAccount();

        It should_return_user_account = () =>
        {
            User.ShouldNotBeNull();
            User.Id.ShouldNotEqual(Guid.Empty);
            User.Name.ShouldNotBeEmpty();
            User.Role.ShouldNotBeEmpty();
            User.State.ShouldNotBeEmpty();
            User.CreatedAt.ShouldNotEqual(DateTime.UtcNow);
        };
    }
}