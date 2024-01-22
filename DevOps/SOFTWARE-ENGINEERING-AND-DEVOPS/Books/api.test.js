const chai = require("chai");
const chaiHttp = require("chai-http");
const server = require("./server");

const expect = chai.expect;

chai.use(chaiHttp);

describe("Books API Tests", () => {
  let requestBody = {
    id: "1",
    title: "DevOps Magic 2",
    author: "Pesho",
  };

  it("should POST a book", (done) => {
    chai.request(server)
    .post("/books")
    .send(requestBody)
    .end((err, resp) => {
        if (err) {
            return done(err)
        }
        expect(resp.statusCode).to.be.equal(201);
        expect(resp.body).to.be.a("object");
        expect(resp.body.id).to.be.equal(requestBody.id);
        expect(resp.body.title).to.be.equal(requestBody.title);
        expect(resp.body.author).to.be.equal(requestBody.author);
        done();
    })
  });
});
