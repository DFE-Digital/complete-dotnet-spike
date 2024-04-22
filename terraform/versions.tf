terraform {
  required_version = ">= 1.5.7"
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.67.0"
    }
    statuscake = {
      source  = "StatusCakeDev/statuscake"
      version = ">= 2.1.0"
    }
  }
}
