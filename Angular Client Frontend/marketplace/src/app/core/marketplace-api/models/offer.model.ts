import { User } from "../../login-api/models/user.model";

export class OfferModel {
  constructor(
    public id: string,
    public categoryId: number,
    public description: string,
    public location: string,
    public pictureUrl: string,
    public publishedOn: string,
    public title: string,
    public userId: number
    ) {
  }
}

export class OfferModelRequest {
  constructor(
    public id: number,
    public CategoryId: string,
    public Description: string,
    public Id: string,
    public Location: string,
    public PictureUrl: string,
    public PublishedOn: string,
    public Title: string,
    public UserId: string,
    public User: string,
    public Category: string
    ) {
  }
}
