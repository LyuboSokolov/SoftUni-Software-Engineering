let { Repository } = require("./solution.js");
let expect = require('chai').expect;

describe("Tests class Repository ", function () {

    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    }

    let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    }

    describe("Test init", function () {

        it("Should be initialisation and add object with correct properties", () => {
            let entity1 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1996, 0, 7)
            }

            let repo = new Repository(properties);
            expect(repo.add(entity)).to.equal(0);
            expect(repo.add(entity1)).to.equal(1);

        });
        it("Should be initialisation and add object with correct properties in correct index", () => {
            let entity1 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1996, 0, 7)
            }

            let repo = new Repository(properties);
            repo.add(entity);
            repo.add(entity1);
            expect(repo.getId(0)).to.equal(entity);
            expect(repo.getId(1)).to.equal(entity1);

        });
        it("Test init properties", () => {
            let repo = new Repository(properties);
            expect(repo.props).to.equal(properties);

        });

        it("Test init Map colection", () => {
            let repo = new Repository(properties);
            expect(repo.data).to.be.an.instanceOf(Map);

        });

        it("Test Get count", () => {
            let repo = new Repository(properties);
            repo.add(entity);
            expect(repo.count).to.equal(1);

            let entity1 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1996, 0, 7)
            }
            repo.add(entity1)
            expect(repo.count).to.equal(2);

        });
    });
    describe("Test add function", () => {
        it("Add with invalid name entity", () => {
            let entity1 = {
                age: 22,
                birthday: new Date(1998, 0, 7)
            }
            let repo = new Repository(properties);
            expect(() => repo.add(entity1)).to.throw(Error, (`Property name is missing from the entity!`));
        })
        it("Add with invalid age entity", () => {
            let entity1 = {
                name: "Pesho",
                birthday: new Date(1998, 0, 7)
            }
            let repo = new Repository(properties);
            expect(() => repo.add(entity1)).to.throw(Error, (`Property age is missing from the entity!`));
        })
        it("Add with invalid birthday entity", () => {
            let entity1 = {
                name: "Pesho",
                age: 22
            }
            let repo = new Repository(properties);
            expect(() => repo.add(entity1)).to.throw(Error, (`Property birthday is missing from the entity!`));
        })

        it("Test getId with invalid id", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
            expect(() => repo.getId(2)).to.throw(Error, (`Entity with id: 2 does not exist!`));
        })
        it("Test getId with valid id must to return ", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
            expect(repo.getId(0)).to.equal(entity);
        })
        it("Test update with invalid id ", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
            expect(repo.getId(0)).to.equal(entity);

            let entity1 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1988, 0, 7)
            }

            expect(() => repo.update(1,entity1)).to.throw(Error,(`Entity with id: 1 does not exist!`));
        })
        it("Test update with valid id ", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
            expect(repo.getId(0)).to.equal(entity);

            let entity1 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1988, 0, 7)
            }
            repo.update(0,entity1);
            expect(repo.getId(0)).to.equal(entity1);
        })
        it("Test update with valid id but invalid object birthday ", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
         

            let entity1 = {
                name: "Gosho",
                age: 32,
                
            }
            expect(() => repo.update(0,entity1)).to.throw(Error,`Property birthday is missing from the entity!`)
        })
        it("Test update with valid id but invalid object name ", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
         

            let entity1 = {
                
                age: 32,
                birthday: new Date(1988, 0, 7)
            }
            expect(() => repo.update(0,entity1)).to.throw(Error,`Property name is missing from the entity!`)
        })

        it("Test del with valid id", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
         

            let entity1 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1988, 0, 7)
            }
            repo.add(entity1);

            repo.del(1);

            expect(repo.count).to.equal(1);
        })

        it("Test del with invalid id", () => {
            
            let repo = new Repository(properties);
            repo.add(entity);
         

            let entity1 = {
                name: "Gosho",
                age: 32,
                birthday: new Date(1988, 0, 7)
            }
            repo.add(entity1);

         expect(() => repo.del(2)).to.throw(Error,`Entity with id: 2 does not exist!`)
        })


    })

});
